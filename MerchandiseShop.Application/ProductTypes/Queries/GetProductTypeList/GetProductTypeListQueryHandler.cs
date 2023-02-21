using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Application.ProductSizes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeList
{
    public class GetProductTypeListQueryHandler : IRequestHandler<GetProductTypeListQuery, ProductTypeListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductTypeListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductTypeListVm> Handle(GetProductTypeListQuery request, CancellationToken cancellationToken)
        {
            var productTypesQuery = await _dbContext.ProductTypes.ProjectTo<ProductTypeDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProductTypeListVm { ProductTypes = productTypesQuery };
        }
    }
}
