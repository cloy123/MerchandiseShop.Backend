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

namespace MerchandiseShop.Application.EventRoles.Commands.UpdateEventRole
{
    public class UpdateEventRoleCommandHandler : IRequestHandler<UpdateEventRoleCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public UpdateEventRoleCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateEventRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventRoles.FirstOrDefaultAsync(eventRole => eventRole.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventRole), request.Id);
            }

            entity.EventId = request.EventId;
            entity.Name = request.Name;
            entity.UserTypeId = request.UserTypeId;
            entity.Prize = request.Prize;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
