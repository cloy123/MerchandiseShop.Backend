using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.FinishEvent
{
    public class FinishEventCommandValidator : AbstractValidator<FinishEventCommand>
    {
        public FinishEventCommandValidator()
        {
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
        }
    }
}
