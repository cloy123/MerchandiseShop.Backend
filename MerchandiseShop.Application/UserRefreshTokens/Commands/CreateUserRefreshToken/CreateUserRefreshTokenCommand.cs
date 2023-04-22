using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Commands.CreateUserRefreshToken
{
    public class CreateUserRefreshTokenCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
