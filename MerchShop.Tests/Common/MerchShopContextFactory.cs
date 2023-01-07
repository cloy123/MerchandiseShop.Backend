using MerchandiseShop.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MerchandiseShop.Domain;
using MerchandiseShop.Domain.Holiday;

namespace MerchShop.Tests.Common
{
    public class MerchShopContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid HolidayIdForDelete = Guid.NewGuid();
        public static Guid HolidayIdForUpdate = Guid.NewGuid();

        public static MerchShopDbContext Create()
        {
            var options = new DbContextOptionsBuilder<MerchShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new MerchShopDbContext(options);
            context.Database.EnsureCreated();
            context.Holidays.AddRange(
                new Holiday
                {
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Name = "Holiday1",
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    IsEveryYear = true,
                    Prize = 100,
                    UserTypeId = 3,
                    GenderId = 2
                },
                new Holiday
                {
                    Id = Guid.Parse("{909F7C29-891B-4BE1-8504-21F84F262084}"),
                    Name = "Holiday2",
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    IsEveryYear = true,
                    Prize = 200,
                    UserTypeId = 3,
                    GenderId = 2
                },
                new Holiday
                {
                    Id = HolidayIdForDelete,
                    Name = "Holiday3",
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    IsEveryYear = true,
                    Prize = 300,
                    UserTypeId = 3,
                    GenderId = 2
                },
                new Holiday
                {
                    Id = HolidayIdForUpdate,
                    Name = "Holiday4",
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    IsEveryYear = true,
                    Prize = 400,
                    UserTypeId = 3,
                    GenderId = 2
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(MerchShopDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
