using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.CurrencyTransactions;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.OrderItems.Commands.DeleteOrderItemFromOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, CancelOrderResultVm>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CancelOrderCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CancelOrderResultVm> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FirstAsync(i => i.Id == request.OrderId, cancellationToken);
            if(order == null)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            if(order.StatusId == OrderStatus.Complete.Id || order.StatusId == OrderStatus.Canceled.Id)
            {
                return new CancelOrderResultVm { ErrorMessage = "Заказ уже выполнен или отменён", IsCanceled = false};
            }

            var orderItems = await _dbContext.OrderItems
                .Include(i => i.Order)
                .Include(i => i.Product)
                .Include(i => i.Product.ProductColor)
                .Include(i => i.Product.ProductType)
                .Include(i => i.Product.ProductSize)
                .Where(i => i.OrderId == request.OrderId).ToListAsync(cancellationToken);

            var sum = 0;
            foreach (var item in orderItems)
            {
                sum += item.Price;
            }

            user.PointBalance += sum;

            await _dbContext.CurrencyTransactions.AddAsync(new CurrencyTransaction
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Date = DateTime.Now,
                CurrencyTransactionTypeId = CurrencyTransactionType.OrderCancelledTransaction.Id,
                Points = sum
            }, cancellationToken);

            order.StatusId = OrderStatus.Canceled.Id;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CancelOrderResultVm
            {
                ErrorMessage = "",
                IsCanceled = true
            };
        }
    }
}
