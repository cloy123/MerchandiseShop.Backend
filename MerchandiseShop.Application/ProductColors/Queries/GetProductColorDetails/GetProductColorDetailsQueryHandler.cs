using AutoMapper;
using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Queries.GetProductColorDetails
{
    public class GetProductColorDetailsQueryHandler : IRequestHandler<GetProductColorDetailsQuery, ProductColorDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductColorDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductColorDetailsVm> Handle(GetProductColorDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductColors.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductColor), request.Id);
            }

            return _mapper.Map<ProductColorDetailsVm>(entity);
        }
    }
}
