using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.CurrencyTransactions;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Products;
using MerchandiseShop.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResultVm>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateOrderCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateOrderResultVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderGuid = Guid.NewGuid();
            if (request.OrderItems != null && request.OrderItems.Any())
            {
                var sum = 0;
                var orderItems = new List<OrderItem>();
                
                foreach(CreateOrderItemDto item in request.OrderItems)
                {
                    var product =  _dbContext.Products
                        .Include(p => p.ProductType)
                        .Include(p => p.ProductColor)
                        .FirstOrDefault(p => p.Id == item.ProductId);
                    if(product == null)
                    {
                        throw new NotFoundException(nameof(Product), item.ProductId);
                    }
                    var freeQuantity = product.Quantity;

                    await _dbContext.OrderItems.Include(i => i.Order)
                        .Where(i => i.ProductId == product.Id && (i.Order.StatusId == OrderStatus.InWork.Id || i.Order.StatusId == OrderStatus.WaitingNewSupply.Id))
                        .ForEachAsync(o => freeQuantity -= o.Quantity, cancellationToken);
                    product.FreeQuantity = freeQuantity;

                    if(product.FreeQuantity < item.Quantity)
                    {
                        return new CreateOrderResultVm
                        {
                            IsCreated = false,
                            ErrorMessage = $"Товара {product.ProductType.Name} {product.ProductColor.Name} нет в налчии в количестве {item.Quantity}"
                        };
                    }
                    var itemPrice = (int)(product.Price - ((double)product.Price * (product.Discount / 100))) * item.Quantity;
                    orderItems.Add(new OrderItem
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        Price = itemPrice,
                        Quantity = item.Quantity,
                        OrderId = orderGuid
                    });
                    sum += itemPrice;
                }
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
                if(user == null)
                {
                    throw new NotFoundException(nameof(User), request.UserId);
                }
                if(user.PointBalance < sum)
                {
                    return new CreateOrderResultVm
                    {
                        IsCreated = false,
                        ErrorMessage = "Недостаточно баллов для заказа"
                    };
                }
                user.PointBalance-=sum;
                await _dbContext.CurrencyTransactions.AddAsync(new CurrencyTransaction
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    Date = DateTime.Now,
                    CurrencyTransactionTypeId = CurrencyTransactionType.OrderCreatedTransaction.Id,
                    Points = 0 - sum
                }, cancellationToken);
                await _dbContext.OrderItems.AddRangeAsync(orderItems, cancellationToken);
            }

            await _dbContext.Orders.AddAsync(new Order
            {
                Id = orderGuid,
                UserId = request.UserId,
                DateCreation = DateTime.Now,
                StatusId = OrderStatus.InWork.Id
            });
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CreateOrderResultVm
            {
                IsCreated = true,
                Id = orderGuid
            };
        }
    }
}
