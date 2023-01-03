using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MerchandiseShop.Domain.Event;

namespace MerchandiseShop.Persistence.EntityTypeConfigurations.EventConfigurations
{
    public class EventResponsibleConfiguration : IEntityTypeConfiguration<EventResponsible>
    {
        public void Configure(EntityTypeBuilder<EventResponsible> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasIndex(r => r.Id).IsUnique();
        }
    }
}
