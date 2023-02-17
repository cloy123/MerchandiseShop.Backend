using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
            RuleFor(h => h.Name).NotEmpty();
            RuleFor(h => h.Date).NotEmpty();
            RuleFor(h => h.Description).NotEmpty();
            RuleFor(h => h.AvalibleFor).NotEmpty();
        }
    }
}
