using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ParkingBooking.API.Models
{
    public partial class ParkingBookingPortalContext : DbContext
    {
        public ParkingBookingPortalContext()
        {
        }

        public ParkingBookingPortalContext(DbContextOptions<ParkingBookingPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingsTable> BookingsTable { get; set; }
        public virtual DbSet<CalenderTable> CalenderTable { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<PaymentTranscationTable> PaymentTranscationTable { get; set; }
        public virtual DbSet<GetBooking_PaymentDetails> GetBooking_PaymentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetBooking_PaymentDetails>(entity => {
                entity.HasNoKey();
            });

            modelBuilder.Entity<BookingsTable>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.Property(e => e.BookingId)
                    .HasColumnName("BookingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookedDates).IsRequired();

                entity.Property(e => e.BookedOn)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CarPlate)
                    .IsRequired()
                    .HasColumnName("CarPlate#")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CalenderTable>(entity =>
            {
                entity.HasKey(e => e.Date);

                entity.Property(e => e.TotalSlots).HasDefaultValueSql("((20))");
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<PaymentTranscationTable>(entity =>
            {
                entity.HasIndex(e => e.BookingId)
                    .HasName("UniqueForeginKey1to1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.PaymentTranscationId)
                    .IsRequired()
                    .HasColumnName("PaymentTranscationID");

                entity.HasOne(d => d.Booking)
                    .WithOne(p => p.PaymentTranscationTable)
                    .HasForeignKey<PaymentTranscationTable>(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTranscationTable_BookingsTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
