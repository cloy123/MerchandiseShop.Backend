using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleDetails
{
    public class GetEventResponsibleDetailsQueryValidator : AbstractValidator<GetEventResponsibleDetailsQuery>
    {
        public GetEventResponsibleDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
