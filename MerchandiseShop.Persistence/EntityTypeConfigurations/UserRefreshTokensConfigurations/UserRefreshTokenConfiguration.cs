using MerchandiseShop.Domain.UserRefreshTokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Persistence.EntityTypeConfigurations.UserRefreshTokensConfigurations
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();
        }
    }
}
