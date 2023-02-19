using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Commands.CreateEventResponsible
{
    public class CreateEventResponsibleCommandValidator : AbstractValidator<CreateEventResponsibleCommand>
    {
        public CreateEventResponsibleCommandValidator()
        {
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
        }
    }
}
