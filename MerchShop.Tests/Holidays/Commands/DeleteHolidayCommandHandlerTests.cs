using MerchandiseShop.Application.Holidays.Commands.DeleteHoliday;
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
    public class DeleteHolidayCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteHolidayCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteHolidayCommandHandler(Context);

            // Act
            await handler.Handle(
                new DeleteHolidayCommand
                {
                    Id = MerchShopContextFactory.HolidayIdForDelete
                },
                CancellationToken.None
                );

            // Assert
            Assert.Null(
                await Context.Holidays.SingleOrDefaultAsync(holiday =>
                    holiday.Id == MerchShopContextFactory.HolidayIdForDelete));
        }
    }
}
