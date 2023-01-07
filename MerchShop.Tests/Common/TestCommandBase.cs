using MerchandiseShop.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchShop.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly MerchShopDbContext Context;

        public TestCommandBase()
        {
            Context = MerchShopContextFactory.Create();
        }

        public void Dispose()
        {
            MerchShopContextFactory.Destroy(Context);
        }
    }
}
