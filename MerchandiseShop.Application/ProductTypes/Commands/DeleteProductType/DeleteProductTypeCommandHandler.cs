using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Commands.DeleteProductType
{
    public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteProductTypeCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductTypes.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductType), request.Id);
            }

            _dbContext.ProductTypes.Remove(entity);
            _dbContext.Products.RemoveRange(_dbContext.Products.Where(p => p.ProductTypeId == request.Id));

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
