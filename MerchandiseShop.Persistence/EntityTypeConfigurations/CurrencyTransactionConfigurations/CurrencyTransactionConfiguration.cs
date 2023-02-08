using MerchandiseShop.Domain.CurrencyTransactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchandiseShop.Persistence.EntityTypeConfigurations.CurrencyTransactionConfigurations
{
    public class CurrencyTransactionConfiguration : IEntityTypeConfiguration<CurrencyTransaction>
    {
        public void Configure(EntityTypeBuilder<CurrencyTransaction> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Id).IsUnique();
        }
    }
}
