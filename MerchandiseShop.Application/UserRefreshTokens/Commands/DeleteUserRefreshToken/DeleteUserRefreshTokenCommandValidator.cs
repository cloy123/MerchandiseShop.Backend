using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Commands.DeleteUserRefreshToken
{
    public class DeleteUserRefreshTokenCommandValidator : AbstractValidator<DeleteUserRefreshTokenCommand>
    {
        public DeleteUserRefreshTokenCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
