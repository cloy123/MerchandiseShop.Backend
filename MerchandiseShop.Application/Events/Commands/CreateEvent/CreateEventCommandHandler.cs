using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateEventCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var event_ = new Event
            {
                Name = request.Name,
                Date = request.Date,
                Description = request.Description
            };
            event_.SetAvalibleFor(request.AvalibleFor);
            await _dbContext.Events.AddAsync(event_, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return event_.Id;
        }
    }
}
