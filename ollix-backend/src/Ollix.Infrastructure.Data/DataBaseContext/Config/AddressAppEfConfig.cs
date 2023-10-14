using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class AddressAppEfConfig : IEntityTypeConfiguration<AddressApp>
    {
        public void Configure(EntityTypeBuilder<AddressApp> builder)
        {
            builder.ToTable(nameof(AddressApp));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.PostalCode)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(p => p.Street)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(p => p.Neighborhood)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(p => p.City)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(p => p.State)
                .HasMaxLength(400)
                .IsRequired();
        }
    }
}
