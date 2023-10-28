using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.OrderAggregate;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class OrderEfConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.OrderNumber)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.RequesterName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.RequesterEmail)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Observation)
                .HasMaxLength(600);

            builder.Property(p => p.OrderStatus)
                .IsRequired();

            builder.Property(p => p.RequestDate)
                .IsRequired();

            builder.Property(p => p.QuantityRequested)
                .IsRequired();

            builder.HasOne(p => p.AddressApp)
                .WithMany()
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(p => p.ClientApp)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
