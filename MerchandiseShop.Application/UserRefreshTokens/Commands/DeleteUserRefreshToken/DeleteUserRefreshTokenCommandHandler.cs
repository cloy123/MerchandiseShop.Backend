using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.UserRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Commands.DeleteUserRefreshToken
{
    public class DeleteUserRefreshTokenCommandHandler : IRequestHandler<DeleteUserRefreshTokenCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteUserRefreshTokenCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUserRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.UserRefreshTokens.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserRefreshToken), request.Id);
            }

            _dbContext.UserRefreshTokens.Remove(entity);
            _dbContext.UserRefreshTokens.RemoveRange(_dbContext.UserRefreshTokens.Where(t => t.Id == request.Id));

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
