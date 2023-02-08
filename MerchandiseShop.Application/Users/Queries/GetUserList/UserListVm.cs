using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Queries.GetUserList
{
    public class UserListVm
    {
        public IList<UserDetailsVm> Users { get; set; }
    }
}
