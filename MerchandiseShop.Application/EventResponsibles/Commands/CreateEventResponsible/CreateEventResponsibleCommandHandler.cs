using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Commands.CreateEventResponsible
{
    public class CreateEventResponsibleCommandHandler : IRequestHandler<CreateEventResponsibleCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateEventResponsibleCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateEventResponsibleCommand request, CancellationToken cancellationToken)
        {
            var eventResponsible = new EventResponsible
            {
                Id = Guid.NewGuid(),
                EventId = request.EventId,
                UserId = request.UserId
            };
            await _dbContext.EventResponsibles.AddAsync(eventResponsible, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return eventResponsible.Id;
        }
    }
}
