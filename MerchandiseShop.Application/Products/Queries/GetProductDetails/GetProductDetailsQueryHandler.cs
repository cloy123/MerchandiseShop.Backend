using AutoMapper;
using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products
                .Include(p => p.ProductSize)
                .Include(p => p.ProductColor)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            var freeQuantity = entity.Quantity;
            
            await _dbContext.OrderItems.Include(i => i.Order)
                .Where(i => i.ProductId == entity.Id && (i.Order.StatusId == OrderStatus.InWork.Id || i.Order.StatusId == OrderStatus.WaitingNewSupply.Id))
                .ForEachAsync(o => freeQuantity-= o.Quantity);

            entity.FreeQuantity = freeQuantity;

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return _mapper.Map<ProductDetailsVm>(entity);
        }
    }
}
