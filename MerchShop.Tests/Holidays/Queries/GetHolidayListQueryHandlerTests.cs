using AutoMapper;
using MerchandiseShop.Application.Holidays.Queries.GetHolidaysList;
using MerchandiseShop.Persistence;
using MerchShop.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace MerchShop.Tests.Holidays.Queries
{
    [Collection("QueryCollection")]
    public class GetHolidayListQueryHandlerTests : TestCommandBase
    {
        private readonly MerchShopDbContext Context;
        private readonly IMapper Mapper;

        public GetHolidayListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetHolidayListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetHolidayListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(new GetHolidayListQuery(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<HolidayListVm>();
            result.Holidays.Count.ShouldBe(4);
        }
    }
}
