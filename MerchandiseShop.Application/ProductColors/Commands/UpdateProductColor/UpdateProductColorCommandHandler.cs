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

namespace MerchandiseShop.Application.ProductColors.Commands.UpdateProductColor
{
    public class UpdateProductColorCommandHandler : IRequestHandler<UpdateProductColorCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public UpdateProductColorCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProductColorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductColors.FirstOrDefaultAsync(productColor => productColor.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductColor), request.Id);
            }

            entity.Name = request.Name;
            entity.Value = request.Value;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
