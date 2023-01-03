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

namespace MerchandiseShop.Application.Holidays.Commands.DeleteHoliday
{
    public class DeleteHolidayCommandHandler : IRequestHandler<DeleteHolidayCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteHolidayCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteHolidayCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Holidays.FindAsync(new object[] { request.Id }, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Holiday), request.Id);
            }

            _dbContext.Holidays.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
