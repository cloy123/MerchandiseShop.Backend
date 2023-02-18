using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantDetails
{
    public class GetEventParticipantDetailsQueryValidator : AbstractValidator<GetEventParticipantDetailsQuery>
    {
        public GetEventParticipantDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
