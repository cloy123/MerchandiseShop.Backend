using MerchandiseShop.Domain.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchandiseShop.Persistence.EntityTypeConfigurations.OrderConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(i => i.Id).IsUnique();
        }
    }
}
