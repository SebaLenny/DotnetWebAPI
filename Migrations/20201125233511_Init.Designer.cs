﻿// <auto-generated />
using System;
using DotnetWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DotnetWebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201125233511_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CarCarCategory", b =>
                {
                    b.Property<int>("CarCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("CarsCarId")
                        .HasColumnType("integer");

                    b.HasKey("CarCategoryId", "CarsCarId");

                    b.HasIndex("CarsCarId");

                    b.ToTable("CarCarCategory");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.CarCategory", b =>
                {
                    b.Property<int>("CarCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CarCategoryId");

                    b.ToTable("CarCategories");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Conditions", b =>
                {
                    b.Property<int>("ConditionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ConditionsId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("DriverNick")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FavouriteNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Rally", b =>
                {
                    b.Property<int>("RallyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CarCategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("RallyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RallyId");

                    b.HasIndex("CarCategoryId");

                    b.HasIndex("OrderId");

                    b.ToTable("Rallies");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.RallyEntry", b =>
                {
                    b.Property<int>("RallyEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("RallyId")
                        .HasColumnType("integer");

                    b.Property<int>("StartingNumber")
                        .HasColumnType("integer");

                    b.HasKey("RallyEntryId");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.HasIndex("RallyId");

                    b.ToTable("RallyEntries");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("DNF")
                        .HasColumnType("boolean");

                    b.Property<int>("RallyEntryId")
                        .HasColumnType("integer");

                    b.Property<int>("StageId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("interval");

                    b.HasKey("ResultId");

                    b.HasIndex("RallyEntryId");

                    b.HasIndex("StageId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Stage", b =>
                {
                    b.Property<int>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("ConditionsId")
                        .HasColumnType("integer");

                    b.Property<int>("RallyId")
                        .HasColumnType("integer");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("StageId");

                    b.HasIndex("ConditionsId");

                    b.HasIndex("RallyId");

                    b.HasIndex("TrackId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("CarCarCategory", b =>
                {
                    b.HasOne("DotnetWebAPI.Models.CarCategory", null)
                        .WithMany()
                        .HasForeignKey("CarCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotnetWebAPI.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Rally", b =>
                {
                    b.HasOne("DotnetWebAPI.Models.CarCategory", "CarCategory")
                        .WithMany("Rallies")
                        .HasForeignKey("CarCategoryId");

                    b.HasOne("DotnetWebAPI.Models.Order", "Order")
                        .WithMany("Rallies")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarCategory");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.RallyEntry", b =>
                {
                    b.HasOne("DotnetWebAPI.Models.Car", "Car")
                        .WithMany("RallyEntries")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotnetWebAPI.Models.Driver", "Driver")
                        .WithMany("RallyEntries")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotnetWebAPI.Models.Rally", "Rally")
                        .WithMany("RallyEntries")
                        .HasForeignKey("RallyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Driver");

                    b.Navigation("Rally");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Result", b =>
                {
                    b.HasOne("DotnetWebAPI.Models.RallyEntry", "RallyEntry")
                        .WithMany("Results")
                        .HasForeignKey("RallyEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotnetWebAPI.Models.Stage", "Stage")
                        .WithMany("Results")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RallyEntry");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Stage", b =>
                {
                    b.HasOne("DotnetWebAPI.Models.Conditions", "Conditions")
                        .WithMany("Stages")
                        .HasForeignKey("ConditionsId");

                    b.HasOne("DotnetWebAPI.Models.Rally", "Rally")
                        .WithMany("Stages")
                        .HasForeignKey("RallyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotnetWebAPI.Models.Track", "Track")
                        .WithMany("Stages")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conditions");

                    b.Navigation("Rally");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Car", b =>
                {
                    b.Navigation("RallyEntries");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.CarCategory", b =>
                {
                    b.Navigation("Rallies");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Conditions", b =>
                {
                    b.Navigation("Stages");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Driver", b =>
                {
                    b.Navigation("RallyEntries");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Order", b =>
                {
                    b.Navigation("Rallies");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Rally", b =>
                {
                    b.Navigation("RallyEntries");

                    b.Navigation("Stages");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.RallyEntry", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Stage", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("DotnetWebAPI.Models.Track", b =>
                {
                    b.Navigation("Stages");
                });
#pragma warning restore 612, 618
        }
    }
}
