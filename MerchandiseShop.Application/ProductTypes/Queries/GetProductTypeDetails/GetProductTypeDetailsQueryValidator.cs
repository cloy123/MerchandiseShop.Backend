using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeDetails
{
    public class GetProductSizeDetailsQueryValidator : AbstractValidator<GetProductTypeDetailsQuery>
    {
        public GetProductSizeDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
