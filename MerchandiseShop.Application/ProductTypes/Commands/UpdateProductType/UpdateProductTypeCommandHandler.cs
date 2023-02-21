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

namespace MerchandiseShop.Application.ProductTypes.Commands.UpdateProductType
{
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public UpdateProductTypeCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductTypes.FirstOrDefaultAsync(productType => productType.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductType), request.Id);
            }

            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
