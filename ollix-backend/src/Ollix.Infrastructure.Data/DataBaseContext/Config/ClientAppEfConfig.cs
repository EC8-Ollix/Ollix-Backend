using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.Domain.ClientAppAggregate;

namespace Ollix.Infrastructure.Data.DataBaseContext.Config
{
    public class ClientAppEfConfig : IEntityTypeConfiguration<ClientApp>
    {
        public void Configure(EntityTypeBuilder<ClientApp> builder)
        {
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
                .IsRequired(true);
        }
    }
}
