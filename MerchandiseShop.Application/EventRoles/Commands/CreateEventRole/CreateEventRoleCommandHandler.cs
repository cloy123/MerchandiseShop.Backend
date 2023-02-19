using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Commands.CreateEventRole
{
    public class CreateEventRoleCommandHandler : IRequestHandler<CreateEventRoleCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateEventRoleCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateEventRoleCommand request, CancellationToken cancellationToken)
        {
            var eventRole = new EventRole
            {
                Id = Guid.NewGuid(),
                EventId = request.EventId,
                Name = request.Name,
                UserTypeId = request.UserTypeId,
                Prize = request.Prize
            };
            await _dbContext.EventRoles.AddAsync(eventRole, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return eventRole.Id;
        }
    }
}
