using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Commands.UpdateEventResponsible
{
    public class UpdateEventResponsibleCommandValidator : AbstractValidator<UpdateEventResponsibleCommand>
    {
        public UpdateEventResponsibleCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
        }
    }
}
