using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Commands.UpdateEventResponsible
{
    public class UpdateEventResponsibleCommandHandler : IRequestHandler<UpdateEventResponsibleCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public UpdateEventResponsibleCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateEventResponsibleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventResponsibles.FirstOrDefaultAsync(eventResponsibles => eventResponsibles.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventResponsible), request.Id);
            }

            entity.EventId = request.EventId;
            entity.UserId = request.UserId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
