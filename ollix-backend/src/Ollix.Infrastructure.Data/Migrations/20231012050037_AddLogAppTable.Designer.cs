﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ollix.Infrastructure.Data.DataBaseContext;

#nullable disable

namespace Ollix.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231012050037_AddLogAppTable")]
    partial class AddLogAppTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ollix.Domain.Aggregates.ClientAppAggregate.ClientApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BussinessName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.ToTable("ClientApp", (string)null);
                });

            modelBuilder.Entity("Ollix.Domain.Aggregates.LogAggregate.LogApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Entity")
                        .HasColumnType("int");

                    b.Property<Guid?>("EntityId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Operation")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("LogApp", (string)null);
                });

            modelBuilder.Entity("Ollix.Domain.Aggregates.UserAppAggregate.UserApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserApp", (string)null);
                });

            modelBuilder.Entity("Ollix.Domain.Aggregates.ClientAppAggregate.ClientApp", b =>
                {
                    b.OwnsOne("Ollix.Domain.ValueObjects.CNPJ", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("ClientAppId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(18)
                                .HasColumnType("nvarchar(18)")
                                .HasColumnName("Cnpj");

                            b1.HasKey("ClientAppId");

                            b1.ToTable("ClientApp");

                            b1.WithOwner()
                                .HasForeignKey("ClientAppId");
                        });

                    b.Navigation("Cnpj");
                });
#pragma warning restore 612, 618
        }
    }
}
