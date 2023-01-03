using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Holiday;
using Microsoft.EntityFrameworkCore;

namespace MerchandiseShop.Application.Holidays.Commands.UpdateHoliday
{
    public class UpdateHolidayCommandHandler : IRequestHandler<UpdateHolidayCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public UpdateHolidayCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateHolidayCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Holidays.FirstOrDefaultAsync(holiday => holiday.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Holiday), request.Id);
            }

            entity.Name = request.Name;
            entity.IsEveryYear = request.IsEveryYear;
            entity.UserTypeId = request.UserTypeId;
            entity.Date = request.Date;
            entity.Prize = request.Prize;
            entity.GenderId = request.GenderId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
