using AutoMapper;
using MerchandiseShop.Application.Holidays.Queries.GetHolidayDetails;
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
using MerchandiseShop.Application.Holidays.Queries;

namespace MerchShop.Tests.Holidays.Queries
{
    [Collection("QueryCollection")]
    public class GetHolidayDetailsQueryHandlerTests : TestCommandBase
    {
        private readonly MerchShopDbContext Context;
        private readonly IMapper Mapper;

        public GetHolidayDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetHolidayDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetHolidayDetailsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(new GetHolidayDetailsQuery() 
                { Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825") 
                }, 
                CancellationToken.None);

            //Assert
            result.ShouldBeOfType<HolidayDetailsVm>();
            result.Name.ShouldBe("Holiday1");
            result.Date.ShouldBe(DateOnly.FromDateTime(DateTime.Now));
            result.IsEveryYear.ShouldBe(true);
            result.Prize.ShouldBe(100);
            result.UserTypeId.ShouldBe(3);
            result.GenderId.ShouldBe(2);
        }
    }
}
