using MerchandiseShop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["dbConnection"];
            services.AddDbContext<MerchShopDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IMerchShopDbContext>(provider => provider.GetService<MerchShopDbContext>());
            return services;
        }
    }
}
