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

namespace MerchandiseShop.Application.Events.Commands.SignupEvent
{
    public class SignupEventCommandHandler : IRequestHandler<SignupEventCommand, SignupEventResultVm>
    {

        private readonly IMerchShopDbContext _dbContext;

        public SignupEventCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SignupEventResultVm> Handle(SignupEventCommand request, CancellationToken cancellationToken)
        {
            var event_ = await _dbContext.Events.FirstOrDefaultAsync(event_ => event_.Id == request.EventId, cancellationToken);

            if (event_ == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }

            if (event_.IsCompleted)
            {
                return new SignupEventResultVm { IsSigned = false, ErrorMessage = "Мероприятие уже завершено" };
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }
            var role = await _dbContext.EventRoles.FirstOrDefaultAsync(r => r.Id == request.EventRoleId, cancellationToken);
            if(role == null)
            {
                throw new NotFoundException(nameof(EventRole), request.EventRoleId);
            }

            var className = "";
            if(user.ClassNumber != null)
            {
                className += user.ClassNumber.ToString();
            }
            if(user.ClassLetter != null)
            {
                className += user.ClassLetter;
            }

            if (!event_.AvalibleFor.Contains(className) || user.UserTypeId != role.UserTypeId)
            {
                return new SignupEventResultVm { IsSigned = false, ErrorMessage = "Мероприятие недоступно для данного пользователя" };
            }

            await _dbContext.EventParticipants.AddAsync(new EventParticipant { EventId = event_.Id, EventRoleId = role.Id, IsVisit = false, UserId = user.Id }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new SignupEventResultVm { IsSigned = true, ErrorMessage = ""};
        }
    }
}
