using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Commands.CreateProductColor
{
    public class CreateProductColorCommandHandler : IRequestHandler<CreateProductColorCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateProductColorCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductColorCommand request, CancellationToken cancellationToken)
        {
            var productColor = new ProductColor
            {
                Name = request.Name,
                Value = request.Value,
                Id = Guid.NewGuid()
            };

            await _dbContext.ProductColors.AddAsync(productColor, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return productColor.Id;
        }
    }
}
