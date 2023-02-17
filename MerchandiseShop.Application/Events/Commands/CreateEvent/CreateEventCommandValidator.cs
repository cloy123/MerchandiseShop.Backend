using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(h => h.Name).NotEmpty();
            RuleFor(h => h.Date).NotEmpty();
            RuleFor(h => h.AvalibleFor).NotEmpty();
            RuleFor(h => h.Description).NotEmpty();
        }
    }
}
