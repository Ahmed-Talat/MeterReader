﻿// <auto-generated />
using System;
using MeterReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeterReader.Migrations
{
    [DbContext(typeof(ReadingContext))]
    [Migration("20221214075243_InitailMigration")]
    partial class InitailMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeterReader.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityTown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateProvince")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address1 = "123 Main Street",
                            CityTown = "Atlanta",
                            PostalCode = "30303",
                            StateProvince = "GA"
                        },
                        new
                        {
                            Id = 2,
                            Address1 = "123 Side Street",
                            CityTown = "Atlanta",
                            PostalCode = "30304",
                            StateProvince = "GA"
                        });
                });

            modelBuilder.Entity("MeterReader.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Name = "Shawn Wildermuth",
                            PhoneNumber = "555-1212"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            Name = "Jake Smith",
                            PhoneNumber = "(404) 555-1212"
                        });
                });

            modelBuilder.Entity("MeterReader.Entities.MeterReading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Readings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            ReadingDate = new DateTime(2022, 12, 14, 9, 52, 43, 111, DateTimeKind.Local).AddTicks(4313),
                            Value = 1458.9000000000001
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            ReadingDate = new DateTime(2022, 12, 14, 9, 52, 43, 111, DateTimeKind.Local).AddTicks(4322),
                            Value = 18403.5
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 2,
                            ReadingDate = new DateTime(2022, 12, 14, 9, 52, 43, 111, DateTimeKind.Local).AddTicks(4323),
                            Value = 0.0
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 2,
                            ReadingDate = new DateTime(2022, 12, 14, 9, 52, 43, 111, DateTimeKind.Local).AddTicks(4324),
                            Value = 304.75
                        });
                });

            modelBuilder.Entity("MeterReader.Entities.Customer", b =>
                {
                    b.HasOne("MeterReader.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MeterReader.Entities.MeterReading", b =>
                {
                    b.HasOne("MeterReader.Entities.Customer", null)
                        .WithMany("Readings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeterReader.Entities.Customer", b =>
                {
                    b.Navigation("Readings");
                });
#pragma warning restore 612, 618
        }
    }
}