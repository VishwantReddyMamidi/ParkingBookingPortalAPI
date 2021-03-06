﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingBooking.API.Models;

namespace ParkingBooking.API.Migrations
{
    [DbContext(typeof(ParkingBookingPortalContext))]
    partial class ParkingBookingPortalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingBooking.API.Models.BookingsTable", b =>
                {
                    b.Property<Guid>("BookingId")
                        .HasColumnName("BookingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookedDates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BookedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("CarPlate")
                        .IsRequired()
                        .HasColumnName("CarPlate#")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("NumberofDaysBooked")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("BookingId");

                    b.ToTable("BookingsTable");
                });

            modelBuilder.Entity("ParkingBooking.API.Models.CalenderTable", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("AvailableSlots")
                        .HasColumnType("int");

                    b.Property<int>("BookedSlots")
                        .HasColumnType("int");

                    b.Property<int>("TotalSlots")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((20))");

                    b.HasKey("Date");

                    b.ToTable("CalenderTable");
                });

            modelBuilder.Entity("ParkingBooking.API.Models.GetBooking_PaymentDetails", b =>
                {
                    b.Property<int>("AmountPaid")
                        .HasColumnType("int");

                    b.Property<string>("BookedDates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BookedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberofDaysBooked")
                        .HasColumnType("int");

                    b.Property<string>("PaymentTranscationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetBooking_PaymentDetails");
                });

            modelBuilder.Entity("ParkingBooking.API.Models.Logins", b =>
                {
                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("ParkingBooking.API.Models.PaymentTranscationTable", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountPaid")
                        .HasColumnType("int");

                    b.Property<Guid>("BookingId")
                        .HasColumnName("BookingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentTranscationId")
                        .IsRequired()
                        .HasColumnName("PaymentTranscationID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StripResponse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique()
                        .HasName("UniqueForeginKey1to1");

                    b.ToTable("PaymentTranscationTable");
                });

            modelBuilder.Entity("ParkingBooking.API.Models.PaymentTranscationTable", b =>
                {
                    b.HasOne("ParkingBooking.API.Models.BookingsTable", "Booking")
                        .WithOne("PaymentTranscationTable")
                        .HasForeignKey("ParkingBooking.API.Models.PaymentTranscationTable", "BookingId")
                        .HasConstraintName("FK_PaymentTranscationTable_BookingsTable")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
