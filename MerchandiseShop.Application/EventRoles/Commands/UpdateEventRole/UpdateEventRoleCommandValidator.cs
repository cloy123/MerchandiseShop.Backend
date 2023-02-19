using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Commands.UpdateEventRole
{
    public class UpdateEventRoleCommandValidator : AbstractValidator<UpdateEventRoleCommand>
    {
        public UpdateEventRoleCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
            RuleFor(h => h.EventId).NotEqual(Guid.Empty);
            RuleFor(h => h.Name).NotEmpty();
            RuleFor(h => h.UserTypeId).NotEmpty();
            RuleFor(h => h.Prize).NotEmpty();
        }
    }
}
