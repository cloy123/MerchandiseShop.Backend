using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Commands.DeleteEventResponsible
{
    public class DeleteEventResponsibleCommandValidator : AbstractValidator<DeleteEventResponsibleCommand>
    {
        public DeleteEventResponsibleCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
