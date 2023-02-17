using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryValidator : AbstractValidator<GetEventDetailsQuery>
    {
        public GetEventDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
