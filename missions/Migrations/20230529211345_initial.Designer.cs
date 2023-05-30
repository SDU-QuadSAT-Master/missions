﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace missions.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230529211345_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AntennaConfig", b =>
                {
                    b.Property<int>("AntennaConfigID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AntennaConfigID"));

                    b.Property<float>("Altitude")
                        .HasColumnType("real");

                    b.Property<float>("Azimuth")
                        .HasColumnType("real");

                    b.Property<float>("Elevation")
                        .HasColumnType("real");

                    b.Property<float>("Frequency")
                        .HasColumnType("real");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<int>("MissionId")
                        .HasColumnType("integer");

                    b.Property<string>("Polarization")
                        .HasColumnType("text");

                    b.Property<string>("Radome")
                        .HasColumnType("text");

                    b.HasKey("AntennaConfigID");

                    b.HasIndex("MissionId")
                        .IsUnique();

                    b.ToTable("AntennaConfigs");
                });

            modelBuilder.Entity("Mission", b =>
                {
                    b.Property<int>("MissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MissionId"));

                    b.Property<string>("Agent")
                        .HasColumnType("text");

                    b.Property<string>("Antenna")
                        .HasColumnType("text");

                    b.Property<string>("Drone")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MissionId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("AntennaConfig", b =>
                {
                    b.HasOne("Mission", null)
                        .WithOne("AntennaConfig")
                        .HasForeignKey("AntennaConfig", "MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mission", b =>
                {
                    b.Navigation("AntennaConfig");
                });
#pragma warning restore 612, 618
        }
    }
}
