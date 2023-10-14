using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.PropellerInfoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class PropellerInfoDateEfConfig : IEntityTypeConfiguration<PropellerInfoDate>
    {
        public void Configure(EntityTypeBuilder<PropellerInfoDate> builder)
        {
            builder.ToTable(nameof(PropellerInfoDate));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.TotalRpm)
                .IsRequired();

            builder.Property(p => p.TotalKwh)
                .IsRequired();

            builder.Property(p => p.ReadingCount)
                .IsRequired();

            builder.Property(p => p.InfoDate)
                .IsRequired();
        }
    }
}
