using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ollix.Domain.Aggregates.UserAppAggregate;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config;

public class UserAppEFConfig : IEntityTypeConfiguration<UserApp>
{
    public void Configure(EntityTypeBuilder<UserApp> builder)
    {
        builder.ToTable(nameof(UserApp));

        builder.HasKey(k => k.Id);

        builder.Property(p => p.FirstName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasMaxLength(200);

        builder.Property(p => p.ClientId)
            .IsRequired();

        builder.Property(p => p.UserType)
            .IsRequired();

        builder.Property(p => p.UserEmail)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.UserPassword)
            .HasMaxLength(200)
            .IsRequired();
    }
}

