using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Commands.CreateProductType
{
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateProductTypeCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = new ProductType
            {
                Name = request.Name,
                Id = Guid.NewGuid()
            };

            await _dbContext.ProductTypes.AddAsync(productType, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return productType.Id;
        }
    }
}
