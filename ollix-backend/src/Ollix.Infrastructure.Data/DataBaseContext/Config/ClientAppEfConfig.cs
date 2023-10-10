using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.ClientAppAggregate;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class ClientAppEfConfig : IEntityTypeConfiguration<ClientApp>
    {
        public void Configure(EntityTypeBuilder<ClientApp> builder)
        {
            builder.ToTable(nameof(ClientApp));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.CompanyName)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(p => p.BussinessName)
                .HasMaxLength(400)
                .IsRequired();

            builder.OwnsOne(x => x.Cnpj)
                .Property(x => x.Value)
                .HasColumnName("Cnpj")
                .HasMaxLength(18)
                .IsRequired();
        }
    }
}
