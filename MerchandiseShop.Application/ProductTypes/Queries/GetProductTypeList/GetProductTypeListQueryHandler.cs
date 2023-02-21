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

namespace MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeList
{
    public class GetProductSizeListQueryHandler : IRequestHandler<GetProductSizeListQuery, ProductSizeListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductSizeListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductSizeListVm> Handle(GetProductSizeListQuery request, CancellationToken cancellationToken)
        {
            var productTypesQuery = await _dbContext.ProductTypes.ProjectTo<ProductSizeListVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProductSizeListVm { ProductTypes = productTypesQuery };
        }
    }
}
