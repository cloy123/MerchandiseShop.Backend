using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Commands.FindUser
{
    public class FindUserVm
    {
        public UserDetailsVm? UserDto { get; set; }
        public bool IsUserFound { get; set; }
        public bool IsPasswordCorrect { get; set; }
        public bool IsAccess { get; set; }
        public string? Token { get; set; }
    }
}
