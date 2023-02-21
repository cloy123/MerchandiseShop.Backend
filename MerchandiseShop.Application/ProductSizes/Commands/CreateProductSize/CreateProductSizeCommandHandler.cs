using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Commands.CreateProductSize
{
    public class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateProductSizeCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
        {
            var productSize = new ProductSize
            {
                Name = request.Name,
                Id = Guid.NewGuid()
            };

            await _dbContext.ProductSizes.AddAsync(productSize, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return productSize.Id;
        }
    }
}
