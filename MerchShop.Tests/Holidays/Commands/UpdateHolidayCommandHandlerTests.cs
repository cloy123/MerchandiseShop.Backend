using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Holidays.Commands.UpdateHoliday;
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
    public class UpdateHolidayCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateHolidayCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateHolidayCommandHandler(Context);
            var updatedName = "new holiday name";

            // Act
            await handler.Handle(
                new UpdateHolidayCommand
                {
                    Name = updatedName,
                    Id = MerchShopContextFactory.HolidayIdForUpdate,
                },
                CancellationToken.None
                );

            // Assert
            Assert.NotNull(
                await Context.Holidays.SingleOrDefaultAsync(holiday =>
                    holiday.Id == MerchShopContextFactory
                    .HolidayIdForUpdate && holiday.Name == updatedName));
        }

        [Fact]
        public async Task CreateHolidayCommandHandler_FailOnwrongId()
        {
            // Arrange
            var handler = new UpdateHolidayCommandHandler(Context);
            var updatedName = "new holiday name";

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async() =>
            {
                await handler.Handle(
                    new UpdateHolidayCommand
                    {
                        Name = updatedName,
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None
                );
            });

        }
    }
}
