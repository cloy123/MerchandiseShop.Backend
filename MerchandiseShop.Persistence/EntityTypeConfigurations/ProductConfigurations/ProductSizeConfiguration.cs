using MerchandiseShop.Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchandiseShop.Persistence.EntityTypeConfigurations.ProductConfigurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id).IsUnique();
        }
    }
}
