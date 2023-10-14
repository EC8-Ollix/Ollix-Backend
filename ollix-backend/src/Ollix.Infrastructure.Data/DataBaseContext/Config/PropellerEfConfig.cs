using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.PropellerAggregate;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class PropellerEfConfig : IEntityTypeConfiguration<Propeller>
    {
        public void Configure(EntityTypeBuilder<Propeller> builder)
        {
            builder.ToTable(nameof(Propeller));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.HelixId)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.Active)
                .IsRequired();

            builder.HasOne(p => p.AddressApp)
                .WithMany()
                .HasForeignKey(e => e.AddressId)
                .IsRequired();

            builder.HasOne(p => p.ClientApp)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
