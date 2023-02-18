using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantList
{
    public class GetEventParticipantListQueryValidator : AbstractValidator<GetEventParticipantListQuery>
    {
        public GetEventParticipantListQueryValidator()
        {
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
        }
    }
}
