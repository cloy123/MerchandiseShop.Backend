using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.UserRefreshTokens
{
    public class UserRefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
