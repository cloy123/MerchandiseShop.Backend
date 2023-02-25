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

namespace MerchandiseShop.Application.OrderItems.Queries.GetOrderItemList
{
    public class GetOrderItemListQueryHandler : IRequestHandler<GetOrderItemListQuery, OrderItemListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderItemListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderItemListVm> Handle(GetOrderItemListQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _dbContext.OrderItems
                .Include(i => i.Order)
                .Include(i => i.Product)
                .Where(i => i.OrderId == request.OrderId)
                .ProjectTo<OrderItemDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new OrderItemListVm { OrderItems = orderItems };
        }
    }
}
