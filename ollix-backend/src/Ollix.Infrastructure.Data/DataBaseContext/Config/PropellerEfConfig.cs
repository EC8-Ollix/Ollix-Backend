using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class PropellerEfConfig : IEntityTypeConfiguration<Propeller>
    {
        public void Configure(EntityTypeBuilder<Propeller> builder)
        {
            builder.ToTable(nameof(Propeller));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Active)
                .IsRequired();

            builder.HasOne(p => p.AddressApp)
                .WithMany()
                .HasForeignKey(e => e.AddressId)
                .IsRequired();

            builder.HasOne(p => p.ClientApp)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .IsRequired();

            builder.HasMany(p => p.PropellerInfoDates)
                .WithOne()
                .HasForeignKey(e => e.PropellerId)
                .IsRequired();

            //builder.HasMany(p => p.PropellerInfoHistorics)
            //    .WithOne()
            //    .HasForeignKey(e => e.PropellerId)
            //    .IsRequired();
        }
    }
}
