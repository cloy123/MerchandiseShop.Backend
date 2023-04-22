using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseShop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Queries.GetUserRefreshTokenList
{
    public class GetUserRefreshTokenListQueryHandler : IRequestHandler<GetUserRefreshTokenListQuery, UserRefreshTokenListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserRefreshTokenListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserRefreshTokenListVm> Handle(GetUserRefreshTokenListQuery request, CancellationToken cancellationToken)
        {
            var userRefreshTokensList = await _dbContext.UserRefreshTokens.Where(u => u.UserId == request.UserId).ProjectTo<UserRefreshTokenDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new UserRefreshTokenListVm { UserRefreshTokens = userRefreshTokensList };
        }
    }
}
