using MerchandiseShop.Domain.Holiday;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchandiseShop.Persistence.EntityTypeConfigurations.HolidayConfigurations
{
    public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.HasKey(h => h.Id);
            builder.HasIndex(h => h.Id).IsUnique();
        }
    }
}
