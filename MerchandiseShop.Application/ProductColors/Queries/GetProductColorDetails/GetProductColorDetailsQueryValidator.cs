using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Queries.GetProductColorDetails
{
    public class GetProductColorDetailsQueryValidator : AbstractValidator<GetProductColorDetailsQuery>
    {
        public GetProductColorDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
