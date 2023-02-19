using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using MerchandiseShop.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Commands.UpdateEventParticipant
{
    public class UpdateEventParticipantCommandHandler : IRequestHandler<UpdateEventParticipantCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public UpdateEventParticipantCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateEventParticipantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventParticipants.FirstOrDefaultAsync(eventParticipant => eventParticipant.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventParticipant), request.Id);
            }

            var event_ = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken);
            if (event_ == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }
            var eventRole = await _dbContext.EventRoles.FirstOrDefaultAsync(e => e.Id == request.EventRoleId, cancellationToken);
            if (eventRole == null)
            {
                throw new NotFoundException(nameof(EventRole), request.EventRoleId);
            }

            if (event_.GetAvalibleFor().Contains(user.ClassNumber.ToString() + user.ClassLetter) && (eventRole.UserTypeId == user.UserTypeId || eventRole.UserTypeId == UserType.All.Id))
            {
                entity.EventId = request.EventId;
                entity.EventRoleId = request.EventRoleId;
                entity.UserId = request.UserId;
                entity.IsVisit = request.IsVisit;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            throw new Exception("event or role is not available for this user");
        }
    }
}
