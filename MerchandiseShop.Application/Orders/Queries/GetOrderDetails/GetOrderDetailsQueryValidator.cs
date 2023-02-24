using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryValidator : AbstractValidator<GetOrderDetailsQuery>
    {
        public GetOrderDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
