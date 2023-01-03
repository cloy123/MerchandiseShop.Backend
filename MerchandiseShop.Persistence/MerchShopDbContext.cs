using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.CurrencyTransaction;
using MerchandiseShop.Domain.Event;
using MerchandiseShop.Domain.Holiday;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Product;
using MerchandiseShop.Domain.Supply;
using MerchandiseShop.Domain.User;
using MerchandiseShop.Persistence.EntityTypeConfigurations.CurrencyTransactionConfigurations;
using MerchandiseShop.Persistence.EntityTypeConfigurations.EventConfigurations;
using MerchandiseShop.Persistence.EntityTypeConfigurations.HolidayConfigurations;
using MerchandiseShop.Persistence.EntityTypeConfigurations.OrderConfigurations;
using MerchandiseShop.Persistence.EntityTypeConfigurations.ProductConfigurations;
using MerchandiseShop.Persistence.EntityTypeConfigurations.SupplyConfigurations;
using MerchandiseShop.Persistence.EntityTypeConfigurations.UserConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MerchandiseShop.Persistence
{
    public class MerchShopDbContext : DbContext, IMerchShopDbContext
    {
        public DbSet<CurrencyTransaction> CurrencyTransactions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<EventResponsible> EventResponsibles { get; set; }
        public DbSet<EventRole> EventRoles { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<User> Users { get; set; }

        public MerchShopDbContext(DbContextOptions<MerchShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CurrencyTransactionConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new EventParticipantConfiguration());
            builder.ApplyConfiguration(new EventResponsibleConfiguration());
            builder.ApplyConfiguration(new EventRoleConfiguration());
            builder.ApplyConfiguration(new HolidayConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new ProductColorConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductPriceConfiguration());
            builder.ApplyConfiguration(new ProductSizeConfiguration());
            builder.ApplyConfiguration(new ProductTypeConfiguration());
            builder.ApplyConfiguration(new SupplyConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
