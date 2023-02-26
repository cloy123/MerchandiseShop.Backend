using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.CurrencyTransactions;
using MerchandiseShop.Domain.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Holidays.Commands.CheckHolidays
{
    public class CheckHolidaysCommandHandler : IRequestHandler<CheckHolidaysCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public CheckHolidaysCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CheckHolidaysCommand request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users.ToListAsync();

            foreach(var user in users)
            {
                if(user.Birthday.Date == DateTime.Now.Date)
                {
                    user.PointBalance += 500;
                    await _dbContext.CurrencyTransactions.AddAsync(new CurrencyTransaction
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Now,
                        UserId = user.Id,
                        Points = 500,
                        CurrencyTransactionTypeId = CurrencyTransactionType.HolidayTransaction.Id
                    });
                    await _dbContext.Notifications.AddAsync(new Notification
                    {
                        Id = Guid.NewGuid(),
                        IsSend = false,
                        DateTime = DateTime.Now,
                        Message = "С Днем рождения!",
                        UserId = user.Id
                    });
                }
            }
            
            var holidays = await _dbContext.Holidays.Where(h => h.Date.Date == DateTime.Now.Date).ToListAsync();
            foreach(var holiday in holidays)
            {
                if(holiday.IsEveryYear && holiday.Date.Date < DateTime.Now.Date)
                {
                    continue;
                }
                foreach(var user in users)
                {
                    if(holiday.UserTypeId == user.UserTypeId && holiday.GenderId == user.GenderId)
                    {
                        user.PointBalance += holiday.Prize;
                        await _dbContext.CurrencyTransactions.AddAsync(new CurrencyTransaction
                        {
                            Id = Guid.NewGuid(),
                            Date = DateTime.Now,
                            UserId = user.Id,
                            Points = holiday.Prize,
                            CurrencyTransactionTypeId = CurrencyTransactionType.HolidayTransaction.Id
                        });
                        await _dbContext.Notifications.AddAsync(new Notification
                        {
                            Id = Guid.NewGuid(),
                            IsSend = false,
                            DateTime = DateTime.Now,
                            Message = $"С {holiday.Name}",
                            UserId = user.Id
                        });
                    }
                }
            }
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
