using AutoMapper;
using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            var orderDetails = _mapper.Map<OrderDetailsVm>(entity);

            orderDetails.OrderItems = await _dbContext.OrderItems
                .Include(i => i.Order)
                .Include(i => i.Product)
                .Where(i => i.OrderId == request.Id).ToListAsync();

            var sum = 0;
            foreach(var item in orderDetails.OrderItems)
            {
                sum += item.Price;
            }
            orderDetails.OrderSum = sum;

            return orderDetails;
        }
    }
}
