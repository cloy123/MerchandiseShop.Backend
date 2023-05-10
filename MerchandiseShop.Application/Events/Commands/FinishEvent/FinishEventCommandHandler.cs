using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.CurrencyTransactions;
using MerchandiseShop.Domain.Event;
using MerchandiseShop.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.FinishEvent
{
    public class FinishEventCommandHandler : IRequestHandler<FinishEventCommand, FinishEventResultVm>
    {
        private readonly IMerchShopDbContext _dbContext;

        public FinishEventCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FinishEventResultVm> Handle(FinishEventCommand request, CancellationToken cancellationToken)
        {
            var event_ = await _dbContext.Events
                .FirstAsync(i => i.Id == request.EventId, cancellationToken);
            if (event_ == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }

            if (event_.IsCompleted)
            {
                return new FinishEventResultVm { IsFinished = false, ErrorMessage = "Мероприятие уже завершено" };
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.ResponsibleId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.ResponsibleId);
            }

            var responsible = await _dbContext.EventResponsibles.FirstOrDefaultAsync(r => r.UserId == request.ResponsibleId, cancellationToken);
            if(responsible == null)
            {
                return new FinishEventResultVm { IsFinished = false, ErrorMessage = "Пользователь не ответственный за мероприятие" };
            }

            var particants = await _dbContext.EventParticipants.Include(r => r.EventRole).Where(p => p.EventId == event_.Id).ToListAsync(cancellationToken);

            foreach (var particant in particants)
            {
                var p = request.Participants.FirstOrDefault(p => p.UserId == particant.UserId);
                if (p == null || p.IsVisit == false)
                {
                    particant.IsVisit = false;
                }
                else
                {
                    particant.IsVisit = true;
                    var pUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == particant.UserId, cancellationToken);
                    if(pUser != null)
                    {
                        pUser.PointBalance += particant.EventRole.Prize;
                        await _dbContext.CurrencyTransactions.AddAsync(new CurrencyTransaction
                        {
                            Id = Guid.NewGuid(),
                            UserId = pUser.Id,
                            Date = DateTime.Now,
                            CurrencyTransactionTypeId = CurrencyTransactionType.EventTransaction.Id,
                            Points = particant.EventRole.Prize
                        }, cancellationToken);
                    }
                }
            }
            event_.IsCompleted = true;

            user.PointBalance += 1000;
            await _dbContext.CurrencyTransactions.AddAsync(new CurrencyTransaction
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Date = DateTime.Now,
                CurrencyTransactionTypeId = CurrencyTransactionType.EventResponsiblesTransaction.Id,
                Points = 1000
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new FinishEventResultVm { IsFinished = true, ErrorMessage = "" };
        }
    }
}
