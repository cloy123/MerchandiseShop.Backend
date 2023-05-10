using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.SignupEvent
{
    public class SignupEventCommandValidator : AbstractValidator<SignupEventCommand>
    {
        public SignupEventCommandValidator()
        {
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
            RuleFor(h => h.EventRoleId).NotEqual(Guid.Empty);
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
        }
    }
}
