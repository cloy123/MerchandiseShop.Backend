using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Commands.DeleteProductColor
{
    public class DeleteProductColorCommandHandler : IRequestHandler<DeleteProductColorCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteProductColorCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductColorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductColors.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductColor), request.Id);
            }

            _dbContext.ProductColors.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
