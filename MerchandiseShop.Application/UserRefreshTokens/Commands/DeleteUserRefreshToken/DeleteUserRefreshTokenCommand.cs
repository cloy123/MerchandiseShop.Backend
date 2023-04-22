using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Commands.DeleteUserRefreshToken
{
    public class DeleteUserRefreshTokenCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
