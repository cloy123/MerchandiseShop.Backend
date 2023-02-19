using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Commands.DeleteEventRole
{
    public class DeleteEventRoleCommandHandler : IRequestHandler<DeleteEventRoleCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteEventRoleCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteEventRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventRoles.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventRole), request.Id);
            }

            _dbContext.EventRoles.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
