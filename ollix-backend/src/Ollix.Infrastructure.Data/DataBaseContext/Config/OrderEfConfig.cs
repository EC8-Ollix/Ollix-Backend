using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class OrderEfConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasKey(k => k.Id);

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

            builder.HasOne(p => p.Propeller)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.PropellerId);

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
