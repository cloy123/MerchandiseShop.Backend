using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Commands.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteUserCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _dbContext.Orders.RemoveRange(_dbContext.Orders.Where(o => o.UserId == request.Id));
            _dbContext.CurrencyTransactions.RemoveRange(_dbContext.CurrencyTransactions.Where(c => c.UserId == request.Id));
            _dbContext.EventParticipants.RemoveRange(_dbContext.EventParticipants.Where(e => e.UserId == request.Id));
            _dbContext.EventResponsibles.RemoveRange(_dbContext.EventResponsibles.Where(e => e.UserId == request.Id));
            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
