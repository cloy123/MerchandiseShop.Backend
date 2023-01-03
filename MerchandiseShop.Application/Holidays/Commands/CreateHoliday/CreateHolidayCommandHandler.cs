using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Holiday;

namespace MerchandiseShop.Application.Holidays.Commands.CreateHoliday
{
    public class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateHolidayCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateHolidayCommand request, CancellationToken cancellationToken)
        {
            var holiday = new Holiday
            {
                Name = request.Name,
                Date = request.Date,
                IsEveryYear = request.IsEveryYear,
                Prize = request.Prize,
                UserTypeId = request.UserTypeId,
                GenderId = request.GenderId,
                Id = Guid.NewGuid()
            };

            await _dbContext.Holidays.AddAsync(holiday, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return holiday.Id;
        }
    }
}
