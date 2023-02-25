using AutoMapper;
using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Application.Orders.Queries.GetOrderDetails;
using MerchandiseShop.Domain.CurrencyTransactions;
using MerchandiseShop.Domain.Notifications;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, OrderDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateOrderStatusCommandHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDetailsVm> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
            if(order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == order.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), user.Id);
            }

            if (order.StatusId != request.StatusId && order.StatusId != OrderStatus.Ready.Id)
            {
                if (request.StatusId == OrderStatus.Canceled.Id)
                {
                    order.StatusId = OrderStatus.Canceled.Id;
                    order.DateCompletion = DateTime.Now;
                    await _dbContext.Notifications.AddAsync(new Notification
                    {
                        Id = Guid.NewGuid(),
                        UserId = order.UserId,
                        IsSend = false,
                        Message = $"Заказ от {order.DateCreation.ToShortDateString()} отменён",
                        DateTime = DateTime.Now
                    }, cancellationToken);
                    var sum = 0;
                    await _dbContext.OrderItems.Where(i => i.OrderId == order.Id).ForEachAsync(action: i =>
                    {
                        sum += i.Price;
                    }, cancellationToken: cancellationToken);
                    user.PointBalance += sum;
                    await _dbContext.CurrencyTransactions.AddAsync(new CurrencyTransaction
                    {
                        Id = Guid.NewGuid(),
                        UserId = order.UserId,
                        Date = (DateTime)order.DateCompletion,
                        CurrencyTransactionTypeId = CurrencyTransactionType.OrderCancelledTransaction.Id,
                        Points = sum
                    }, cancellationToken);
                }else if(request.StatusId == OrderStatus.WaitingNewSupply.Id)
                {
                    order.StatusId = OrderStatus.WaitingNewSupply.Id;
                    await _dbContext.Notifications.AddAsync(new Notification
                    {
                        Id = Guid.NewGuid(),
                        UserId = order.UserId,
                        IsSend = false,
                        Message = $"Заказ от {order.DateCreation.ToShortDateString()} задерживается",
                        DateTime = DateTime.Now
                    }, cancellationToken);
                }else if(request.StatusId == OrderStatus.Ready.Id)
                {
                    order.StatusId = OrderStatus.Ready.Id;
                    order.DateCompletion = DateTime.Now;
                    await _dbContext.Notifications.AddAsync(new Notification
                    {
                        Id = Guid.NewGuid(),
                        UserId = order.UserId,
                        IsSend = false,
                        Message = $"Заказ от {order.DateCreation.ToShortDateString()} можно забирать",
                        DateTime = DateTime.Now
                    }, cancellationToken);
                    await _dbContext.OrderItems.Where(i => i.OrderId == order.Id).ForEachAsync(action: i =>
                    {
                        var product = _dbContext.Products.FirstOrDefault(p => p.Id == i.ProductId);
                        if(product != null)
                        {
                            product.Quantity -= i.Quantity;
                        }
                    }, cancellationToken);
                }
            }
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new GetOrderDetailsQueryHandler(_dbContext, _mapper).Handle(new GetOrderDetailsQuery { Id = request.Id}, cancellationToken).Result;
        }
    }
}
