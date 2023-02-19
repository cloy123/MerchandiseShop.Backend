using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Queries.GetEventRoleList
{
    public class GetEventRoleListQueryValidator : AbstractValidator<GetEventRoleListQuery>
    {
        public GetEventRoleListQueryValidator()
        {
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
        }
    }
}
