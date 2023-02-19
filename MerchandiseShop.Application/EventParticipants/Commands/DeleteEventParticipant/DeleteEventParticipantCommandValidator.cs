using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Commands.DeleteEventParticipant
{
    public class DeleteEventParticipantCommandValidator : AbstractValidator<DeleteEventParticipantCommand>
    {
        public DeleteEventParticipantCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
