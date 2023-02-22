using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateProductCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductTypeId = request.ProductTypeId,
                ProductSizeId = request.ProductSizeId,
                ProductColorId = request.ProductColorId,
                ShowInCatalog = request.ShowInCatalog,
                Quantity = request.Quantity,
                MinQuantity = request.MinQuantity,
                Price = request.Price,
                Discount = request.Discount,
                ImageFileName = request.ImageFileName,
                Id = Guid.NewGuid()
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
