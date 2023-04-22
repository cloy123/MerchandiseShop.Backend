using MerchandiseShop.Domain.UserRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Queries.GetUserRefreshTokenList
{
    public class UserRefreshTokenListVm
    {
        public IList<UserRefreshTokenDetailsVm> UserRefreshTokens { get; set; }
    }
}
