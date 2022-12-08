﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpotAss18_10_2022.Models;

#nullable disable

namespace SpotAss18_10_2022.Migrations
{
    [DbContext(typeof(InfoDbContext))]
    [Migration("20221018072354_lastMigration")]
    partial class lastMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SpotAss18_10_2022.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"), 1L, 1);

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffId");

                    b.ToTable("Staff");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Staff");
                });

            modelBuilder.Entity("SpotAss18_10_2022.Models.Doctor", b =>
                {
                    b.HasBaseType("SpotAss18_10_2022.Models.Staff");

                    b.Property<int>("NumberOperations")
                        .HasColumnType("int");

                    b.Property<int>("PatientsDaigonised")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Doctor");

                    b.HasData(
                        new
                        {
                            StaffId = 1,
                            Contact = "84652",
                            StaffCategory = "Doctor",
                            StaffName = "Pawan",
                            NumberOperations = 4,
                            PatientsDaigonised = 5
                        },
                        new
                        {
                            StaffId = 2,
                            Contact = "7372",
                            StaffCategory = "Doctor",
                            StaffName = "Mohan",
                            NumberOperations = 3,
                            PatientsDaigonised = 2
                        });
                });

            modelBuilder.Entity("SpotAss18_10_2022.Models.Nurse", b =>
                {
                    b.HasBaseType("SpotAss18_10_2022.Models.Staff");

                    b.Property<int>("NumberOfInjections")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPatientsMonitored")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Nurse");

                    b.HasData(
                        new
                        {
                            StaffId = 3,
                            Contact = "7453",
                            StaffCategory = "Nurse",
                            StaffName = "Rani",
                            NumberOfInjections = 34,
                            NumberOfPatientsMonitored = 4
                        },
                        new
                        {
                            StaffId = 4,
                            Contact = "7462",
                            StaffCategory = "Nurse",
                            StaffName = "Jammy",
                            NumberOfInjections = 5,
                            NumberOfPatientsMonitored = 7
                        });
                });

            modelBuilder.Entity("SpotAss18_10_2022.Models.WardBoy", b =>
                {
                    b.HasBaseType("SpotAss18_10_2022.Models.Staff");

                    b.Property<int>("NumberRoomsCleaned")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("WardBoy");

                    b.HasData(
                        new
                        {
                            StaffId = 5,
                            Contact = "7453",
                            StaffCategory = "WardBoy",
                            StaffName = "Amar",
                            NumberRoomsCleaned = 5
                        },
                        new
                        {
                            StaffId = 6,
                            Contact = "3464",
                            StaffCategory = "WardBoy",
                            StaffName = "Bam",
                            NumberRoomsCleaned = 8
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
