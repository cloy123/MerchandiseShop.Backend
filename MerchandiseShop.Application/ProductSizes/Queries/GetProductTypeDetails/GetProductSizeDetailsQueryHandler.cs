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

namespace MerchandiseShop.Application.ProductSizes.Queries.GetProductSizeDetails
{
    public class GetProductSizeDetailsQueryHandler : IRequestHandler<GetProductSizeDetailsQuery, ProductSizeDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductSizeDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductSizeDetailsVm> Handle(GetProductSizeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductSizes.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductSize), request.Id);
            }

            return _mapper.Map<ProductSizeDetailsVm>(entity);
        }
    }
}
