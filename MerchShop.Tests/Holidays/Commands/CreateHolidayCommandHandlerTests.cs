using MerchandiseShop.Application.Holidays.Commands.CreateHoliday;
using MerchShop.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MerchShop.Tests.Holidays.Commands
{
    public class CreateHolidayCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateHolidayCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateHolidayCommandHandler(Context);
            var holidayName = "holiday name";
            var holidayDate = DateOnly.FromDateTime(DateTime.Now);
            var holidayIsEveryYear = true;
            var holidayPrize = 199;
            var holidayUserTypeId = 3;
            var holidayGenderId = 2;

            // Act
            var holidayId = await handler.Handle(
                new CreateHolidayCommand
                {
                    Name = holidayName,
                    Date = holidayDate,
                    IsEveryYear = holidayIsEveryYear,
                    Prize = holidayPrize,
                    UserTypeId = holidayUserTypeId,
                    GenderId = holidayGenderId
                },
                CancellationToken.None
                );

            // Assert
            Assert.NotNull(
                await Context.Holidays.SingleOrDefaultAsync(holiday =>
                    holiday.Id == holidayId &&
                    holiday.Name == holidayName &&
                    holiday.Date == holidayDate &&
                    holiday.IsEveryYear == holidayIsEveryYear &&
                    holiday.Prize == holidayPrize &&
                    holiday.UserTypeId == holidayUserTypeId &&
                    holiday.GenderId == holidayGenderId));
        }
    }
}
