using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Queries.GetUserRefreshTokenList
{
    public class GetUserRefreshTokenListQueryValidator : AbstractValidator<GetUserRefreshTokenListQuery>
    {
        public GetUserRefreshTokenListQueryValidator()
        {
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
        }
    }
}
