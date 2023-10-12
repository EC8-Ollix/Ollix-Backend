using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class LogAppEFConfig : IEntityTypeConfiguration<LogApp>
    {
        public void Configure(EntityTypeBuilder<LogApp> builder)
        {
            builder.ToTable(nameof(LogApp));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Entity)
                .IsRequired();

            builder.Property(p => p.Operation)
                .IsRequired();

            builder.Property(p => p.EntityId)
                .IsRequired();

            builder.HasOne(p => p.UserApp)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(p => p.ClientApp)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(p => p.Date)
                .IsRequired();
        }
    }
}
