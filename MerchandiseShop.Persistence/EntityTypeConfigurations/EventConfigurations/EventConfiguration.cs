using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MerchandiseShop.Domain.Event;

namespace MerchandiseShop.Persistence.EntityTypeConfigurations.EventConfigurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id).IsUnique();
        }
    }
}
