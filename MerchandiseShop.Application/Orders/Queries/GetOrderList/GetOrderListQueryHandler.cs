using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseShop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Orders
                .Include(o => o.User)
                .ProjectTo<OrderDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach(var order in orders)
            {
                order.OrderItems = await _dbContext.OrderItems
                .Include(i => i.Order)
                .Include(i => i.Product)
                .Where(i => i.OrderId == order.Id).ToListAsync(cancellationToken);

                var sum = 0;
                foreach (var item in order.OrderItems)
                {
                    sum += item.Price;
                }
                order.OrderSum = sum;
            }

            return new OrderListVm { Orders = orders };
        }
    }
}
