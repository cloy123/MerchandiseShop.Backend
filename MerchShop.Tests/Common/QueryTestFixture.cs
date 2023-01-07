using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Persistence;
using Xunit;

namespace MerchShop.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public MerchShopDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = MerchShopContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IMerchShopDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            MerchShopContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
