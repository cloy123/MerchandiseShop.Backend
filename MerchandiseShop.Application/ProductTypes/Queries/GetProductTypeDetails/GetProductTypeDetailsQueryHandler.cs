using AutoMapper;
using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeDetails
{
    public class GetProductTypeDetailsQueryHandler : IRequestHandler<GetProductTypeDetailsQuery, ProductTypeDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductTypeDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductTypeDetailsVm> Handle(GetProductTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductTypes.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductType), request.Id);
            }

            return _mapper.Map<ProductTypeDetailsVm>(entity);
        }
    }
}
