using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteEventCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            _dbContext.EventParticipants.RemoveRange(_dbContext.EventParticipants.Where(e => e.EventId == request.Id));
            _dbContext.EventResponsibles.RemoveRange(_dbContext.EventResponsibles.Where(e => e.EventId == request.Id));
            _dbContext.EventRoles.RemoveRange(_dbContext.EventRoles.Where(e => e.EventId == request.Id));
            _dbContext.Events.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
