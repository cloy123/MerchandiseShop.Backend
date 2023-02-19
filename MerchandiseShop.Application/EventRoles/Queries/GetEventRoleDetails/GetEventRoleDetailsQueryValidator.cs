using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Queries.GetEventRoleDetails
{
    public class GetEventRoleDetailsQueryValidator : AbstractValidator<GetEventRoleDetailsQuery>
    {
        public GetEventRoleDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
