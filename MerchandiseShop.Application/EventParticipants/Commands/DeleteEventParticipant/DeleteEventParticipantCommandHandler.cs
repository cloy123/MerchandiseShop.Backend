using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Commands.DeleteEventParticipant
{
    public class DeleteEventParticipantCommandHandler : IRequestHandler<DeleteEventParticipantCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteEventParticipantCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteEventParticipantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventParticipants.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventParticipant), request.Id);
            }

            _dbContext.EventParticipants.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
