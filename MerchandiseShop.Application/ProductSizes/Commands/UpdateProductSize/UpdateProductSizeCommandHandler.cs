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

namespace MerchandiseShop.Application.ProductSizes.Commands.UpdateProductSize
{
    public class UpdateProductSizeCommandHandler : IRequestHandler<UpdateProductSizeCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public UpdateProductSizeCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProductSizeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductSizes.FirstOrDefaultAsync(productSize => productSize.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductSize), request.Id);
            }

            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
