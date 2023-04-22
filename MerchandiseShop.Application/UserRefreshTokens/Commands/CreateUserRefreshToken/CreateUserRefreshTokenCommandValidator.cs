using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Commands.CreateUserRefreshToken
{
    public class CreateUserRefreshTokenCommandValidator : AbstractValidator<CreateUserRefreshTokenCommand>
    {
        public CreateUserRefreshTokenCommandValidator()
        {
            RuleFor(h => h.RefreshToken).NotEmpty();
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
        }
    }
}
