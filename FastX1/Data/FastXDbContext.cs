using Microsoft.EntityFrameworkCore;
using FastX1.Models;
using BusRoute = FastX1.Models.BusRoute;
namespace FastX1.Data
{
    public class FastXDbContext : DbContext
    {
        public FastXDbContext(DbContextOptions<FastXDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BusOperator> BusOperators { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusRoute> Routes { get; set; }
        public DbSet<BusSchedule> BusSchedules { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingSeat> BookingSeats { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CancellationLog> CancellationLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BookingSeat → Seat (many-to-one)
            modelBuilder.Entity<BookingSeat>()
                .HasOne(bs => bs.Seat)
                .WithMany(s => s.BookingSeats) // use navigation property in Seat.cs
                .HasForeignKey(bs => bs.SeatID)
                .OnDelete(DeleteBehavior.Restrict); // or NoAction

            // BookingSeat → Booking (many-to-one)
            modelBuilder.Entity<BookingSeat>()
                .HasOne(bs => bs.Booking)
                .WithMany(b => b.BookingSeats) // use navigation property in Booking.cs
                .HasForeignKey(bs => bs.BookingID)
                .OnDelete(DeleteBehavior.Cascade); // this can be Cascade
        }

    }
}