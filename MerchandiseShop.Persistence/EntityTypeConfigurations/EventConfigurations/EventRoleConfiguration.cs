using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MerchandiseShop.Domain.Event;

namespace MerchandiseShop.Persistence.EntityTypeConfigurations.EventConfigurations
{
    public class EventRoleConfiguration : IEntityTypeConfiguration<EventRole>
    {
        public void Configure(EntityTypeBuilder<EventRole> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasIndex(r => r.Id).IsUnique();
        }
    }
}
