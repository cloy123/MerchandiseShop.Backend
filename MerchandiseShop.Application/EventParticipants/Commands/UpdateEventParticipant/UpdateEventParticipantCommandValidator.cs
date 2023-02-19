using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Commands.UpdateEventParticipant
{
    public class UpdateEventParticipantCommandValidator : AbstractValidator<UpdateEventParticipantCommand>
    {
        public UpdateEventParticipantCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
            RuleFor(h => h.EventRoleId).NotEqual(Guid.Empty);
            RuleFor(h => h.IsVisit).NotEmpty();
        }
    }
}
