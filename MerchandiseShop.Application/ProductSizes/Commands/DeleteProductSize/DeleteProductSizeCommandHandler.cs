using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Commands.DeleteProductSize
{
    public class DeleteProductSizeCommandHandler : IRequestHandler<DeleteProductSizeCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteProductSizeCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductSizeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductSizes.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductSize), request.Id);
            }

            _dbContext.ProductSizes.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
