using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleList
{
    public class GetEventResponsibleListQueryValidator : AbstractValidator<GetEventResponsibleListQuery>
    {
        public GetEventResponsibleListQueryValidator()
        {
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
        }
    }
}
