﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortBasicManager.Entities;

#nullable disable

namespace PortBasicManager.Migrations
{
    [DbContext(typeof(PortBasicContext))]
    [Migration("20241024072929_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Finnish_Swedish_CI_AI")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortBasicManager.Port", b =>
                {
                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int?>("FreeSlots")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Occupancy")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("VesselId")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("SlotId")
                        .HasName("PK_Port");

                    b.ToTable("Ports", (string)null);

                    b.HasData(
                        new
                        {
                            SlotId = 1,
                            Id = 1,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 2,
                            Id = 2,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 3,
                            Id = 3,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 4,
                            Id = 4,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 5,
                            Id = 5,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 6,
                            Id = 6,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 7,
                            Id = 7,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 8,
                            Id = 8,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 9,
                            Id = 9,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 10,
                            Id = 10,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 11,
                            Id = 11,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 12,
                            Id = 12,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 13,
                            Id = 13,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 14,
                            Id = 14,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 15,
                            Id = 15,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 16,
                            Id = 16,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 17,
                            Id = 17,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 18,
                            Id = 18,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 19,
                            Id = 19,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 20,
                            Id = 20,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 21,
                            Id = 21,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 22,
                            Id = 22,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 23,
                            Id = 23,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 24,
                            Id = 24,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 25,
                            Id = 25,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 26,
                            Id = 26,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 27,
                            Id = 27,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 28,
                            Id = 28,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 29,
                            Id = 29,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 30,
                            Id = 30,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 31,
                            Id = 31,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 32,
                            Id = 32,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 33,
                            Id = 33,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 34,
                            Id = 34,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 35,
                            Id = 35,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 36,
                            Id = 36,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 37,
                            Id = 37,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 38,
                            Id = 38,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 39,
                            Id = 39,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 40,
                            Id = 40,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 41,
                            Id = 41,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 42,
                            Id = 42,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 43,
                            Id = 43,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 44,
                            Id = 44,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 45,
                            Id = 45,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 46,
                            Id = 46,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 47,
                            Id = 47,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 48,
                            Id = 48,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 49,
                            Id = 49,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 50,
                            Id = 50,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 51,
                            Id = 51,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 52,
                            Id = 52,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 53,
                            Id = 53,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 54,
                            Id = 54,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 55,
                            Id = 55,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 56,
                            Id = 56,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 57,
                            Id = 57,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 58,
                            Id = 58,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 59,
                            Id = 59,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 60,
                            Id = 60,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 61,
                            Id = 61,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 62,
                            Id = 62,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 63,
                            Id = 63,
                            Occupancy = 0m
                        },
                        new
                        {
                            SlotId = 64,
                            Id = 64,
                            Occupancy = 0m
                        });
                });

            modelBuilder.Entity("PortBasicManager.RejectedVessel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("VesselId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id")
                        .HasName("PK_RejectedVessel");

                    b.ToTable("RejectedVessels", (string)null);
                });

            modelBuilder.Entity("PortBasicManager.Vessel", b =>
                {
                    b.Property<string>("VesselId")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<int?>("LayTime")
                        .HasColumnType("int");

                    b.Property<int>("PortSlotId")
                        .HasColumnType("int");

                    b.Property<double?>("SpeedInKnots")
                        .HasColumnType("float");

                    b.Property<double>("VesselSize")
                        .HasColumnType("float");

                    b.Property<string>("VesselType")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double?>("WeightInKg")
                        .HasColumnType("float");

                    b.HasKey("VesselId")
                        .HasName("PK_Vessel");

                    b.HasIndex("PortSlotId");

                    b.ToTable("Vessels", (string)null);

                    b.HasDiscriminator<string>("VesselType").HasValue("Vessel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PortBasicManager.CargoShip", b =>
                {
                    b.HasBaseType("PortBasicManager.Vessel");

                    b.Property<int>("NumberOfContainers")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("CargoShip");
                });

            modelBuilder.Entity("PortBasicManager.MotorBoat", b =>
                {
                    b.HasBaseType("PortBasicManager.Vessel");

                    b.Property<double>("NumberOfHorsepower")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Motorboat");
                });

            modelBuilder.Entity("PortBasicManager.RowBoat", b =>
                {
                    b.HasBaseType("PortBasicManager.Vessel");

                    b.Property<int>("NumberOfPassengers")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Rowboat");
                });

            modelBuilder.Entity("PortBasicManager.SailBoat", b =>
                {
                    b.HasBaseType("PortBasicManager.Vessel");

                    b.Property<double>("LengthOfSailboat")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Sailboat");
                });

            modelBuilder.Entity("PortBasicManager.Vessel", b =>
                {
                    b.HasOne("PortBasicManager.Port", "Port")
                        .WithMany("Vessel")
                        .HasForeignKey("PortSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Port");
                });

            modelBuilder.Entity("PortBasicManager.Port", b =>
                {
                    b.Navigation("Vessel");
                });
#pragma warning restore 612, 618
        }
    }
}
