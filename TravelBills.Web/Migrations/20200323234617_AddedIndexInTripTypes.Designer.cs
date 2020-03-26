﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelBills.Web.Data;

namespace TravelBills.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200323234617_AddedIndexInTripTypes")]
    partial class AddedIndexInTripTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelBills.Web.Data.Entities.TripDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("BillValue");

                    b.Property<string>("PicturePath");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("Time");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("TravelBills.Web.Data.Entities.TripEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("VisitedCity")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TravelBills.Web.Data.Entities.TripExpenseTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TripDetailId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("TripDetailId");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("TripExpenseTypes");
                });

            modelBuilder.Entity("TravelBills.Web.Data.Entities.TripTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TripId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("TripTypes");
                });

            modelBuilder.Entity("TravelBills.Web.Data.Entities.TripDetailEntity", b =>
                {
                    b.HasOne("TravelBills.Web.Data.Entities.TripEntity", "Trip")
                        .WithMany("TripDetails")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("TravelBills.Web.Data.Entities.TripExpenseTypeEntity", b =>
                {
                    b.HasOne("TravelBills.Web.Data.Entities.TripDetailEntity", "TripDetail")
                        .WithMany("TripExpenseTypes")
                        .HasForeignKey("TripDetailId");
                });

            modelBuilder.Entity("TravelBills.Web.Data.Entities.TripTypeEntity", b =>
                {
                    b.HasOne("TravelBills.Web.Data.Entities.TripEntity", "Trip")
                        .WithMany("TripTypes")
                        .HasForeignKey("TripId");
                });
#pragma warning restore 612, 618
        }
    }
}