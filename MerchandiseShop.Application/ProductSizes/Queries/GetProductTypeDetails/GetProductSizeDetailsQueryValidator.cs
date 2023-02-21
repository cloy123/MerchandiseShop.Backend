using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Queries.GetProductSizeDetails
{
    public class GetProductSizeDetailsQueryValidator : AbstractValidator<GetProductSizeDetailsQuery>
    {
        public GetProductSizeDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
