using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Commands.CreateEventParticipant
{
    public class CreateEventParticipantCommandValidator : AbstractValidator<CreateEventParticipantCommand>
    {
        public CreateEventParticipantCommandValidator()
        {
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
            RuleFor(h => h.EventRoleId).NotEqual(Guid.Empty);
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
        }
    }
}
