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

namespace MerchandiseShop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public UpdateProductCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            entity.ProductTypeId = request.ProductTypeId;
            entity.ProductSizeId = request.ProductSizeId;
            entity.ProductColorId = request.ProductColorId;
            entity.ShowInCatalog = request.ShowInCatalog;
            entity.Quantity = request.Quantity;
            entity.MinQuantity = request.MinQuantity;
            entity.Price = request.Price;
            entity.Discount = request.Discount;
            entity.ImageFileName = request.ImageFileName;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
