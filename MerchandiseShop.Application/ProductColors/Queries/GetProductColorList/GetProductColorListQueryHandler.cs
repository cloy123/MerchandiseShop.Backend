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

namespace MerchandiseShop.Application.ProductColors.Queries.GetProductColorList
{
    public class GetProductColorListQueryHandler : IRequestHandler<GetProductColorListQuery, ProductColorListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductColorListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductColorListVm> Handle(GetProductColorListQuery request, CancellationToken cancellationToken)
        {
            var productColorQuery = await _dbContext.ProductColors.ProjectTo<ProductColorDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProductColorListVm { ProductColors = productColorQuery };
        }
    }
}
