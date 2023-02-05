using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Commands.FindUser
{
    public class FindUserCommand : IRequest<FindUserVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
