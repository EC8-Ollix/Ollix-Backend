using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.LogAggregate;

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

            builder.Property(p => p.UserName)
                .IsRequired();

            builder.HasOne(p => p.ClientApp)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(p => p.Date)
                .IsRequired();
        }
    }
}
