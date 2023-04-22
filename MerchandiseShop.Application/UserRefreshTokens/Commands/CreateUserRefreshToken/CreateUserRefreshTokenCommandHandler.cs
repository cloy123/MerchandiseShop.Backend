using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.UserRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Commands.CreateUserRefreshToken
{
    public class CreateUserRefreshTokenCommandHandler : IRequestHandler<CreateUserRefreshTokenCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateUserRefreshTokenCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateUserRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userRefreshToken = new UserRefreshToken
            {
                Id = Guid.NewGuid(),
                RefreshToken = request.RefreshToken,
                UserId = request.UserId
            };

            await _dbContext.UserRefreshTokens.AddAsync(userRefreshToken, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return userRefreshToken.Id;
        }
    }
}
