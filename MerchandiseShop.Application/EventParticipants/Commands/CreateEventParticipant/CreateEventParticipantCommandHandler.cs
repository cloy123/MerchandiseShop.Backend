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

namespace MerchandiseShop.Application.EventParticipants.Commands.CreateEventParticipant
{
    public class CreateEventParticipantCommandHandler : IRequestHandler<CreateEventParticipantCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateEventParticipantCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateEventParticipantCommand request, CancellationToken cancellationToken)
        {
            var event_ = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken);
            if (event_ == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            if(user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }
            var eventRole = await _dbContext.EventRoles.FirstOrDefaultAsync(e => e.Id == request.EventRoleId, cancellationToken);
            if (eventRole == null)
            {
                throw new NotFoundException(nameof(EventRole), request.EventRoleId);
            }
            if(event_.GetAvalibleFor().Contains(user.ClassNumber.ToString() + user.ClassLetter) && (eventRole.UserTypeId == user.UserTypeId || eventRole.UserTypeId == UserType.All.Id))
            {
                var eventParticipant = new EventParticipant
                {
                    Id = Guid.NewGuid(),
                    EventId = request.EventId,
                    EventRoleId = request.EventRoleId,
                    UserId = request.UserId,
                    IsVisit = false
                };
                await _dbContext.EventParticipants.AddAsync(eventParticipant, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return eventParticipant.Id;
            }
            throw new Exception("event or role is not available for this user");
        }
    }
}
