using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Id).NotEqual(Guid.Empty);
            RuleFor(u => u.IsAccess).NotEmpty();
            RuleFor(u => u.UserTypeId).NotEmpty();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Birthday).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.PointBalance).NotEmpty();
            RuleFor(u => u.ClassNumber);
            RuleFor(u => u.ClassLetter);
            RuleFor(u => u.GenderId).NotEmpty();
            RuleFor(u => u.NewPassword);
        }
    }
}
