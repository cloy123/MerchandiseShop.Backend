using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Commands.CreateEventRole
{
    public class CreateEventRoleCommandValidator : AbstractValidator<CreateEventRoleCommand>
    {
        public CreateEventRoleCommandValidator()
        {
            RuleFor(h => h.Name).NotEmpty();
            RuleFor(h => h.UserTypeId).NotEmpty();
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
            RuleFor(h => h.Prize).NotEmpty();
        }
    }
}
