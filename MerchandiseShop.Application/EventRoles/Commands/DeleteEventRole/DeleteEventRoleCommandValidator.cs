using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Commands.DeleteEventRole
{
    public class DeleteEventRoleCommandValidator : AbstractValidator<DeleteEventRoleCommand>
    {
        public DeleteEventRoleCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
