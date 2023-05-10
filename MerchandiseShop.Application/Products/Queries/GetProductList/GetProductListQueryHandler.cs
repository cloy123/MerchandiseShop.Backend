using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var productQuery = _dbContext.Products
                .Include(p => p.ProductColor)
                .Include(p => p.ProductType)
                .Include(p => p.ProductSize);

            var orderItems = _dbContext.OrderItems.Include(i => i.Order);

            foreach(Product product in productQuery)
            {
                var freeQuantity = product.Quantity;

                await orderItems
                    .Where(i => i.ProductId == product.Id && (i.Order.StatusId == OrderStatus.InWork.Id || i.Order.StatusId == OrderStatus.WaitingNewSupply.Id))
                    .ForEachAsync(o => freeQuantity -= o.Quantity, cancellationToken);

                product.FreeQuantity = freeQuantity;
            }

            var products = await productQuery.ProjectTo<ProductDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProductListVm { Products = products };
        }
    }
}
