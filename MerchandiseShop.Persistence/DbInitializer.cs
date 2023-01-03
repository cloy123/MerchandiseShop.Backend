﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(MerchShopDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
