using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Queries.GetUserRefreshTokenList
{
    public class GetUserRefreshTokenListQuery : IRequest<UserRefreshTokenListVm>
    {
        public Guid UserId { get; set; }
    }
}
