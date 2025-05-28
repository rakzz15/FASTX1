using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Repositories.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FastXDbContext _context;

        public BookingRepository(FastXDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> GetByIdAsync(int bookingId)
        {
            return await _context.Bookings
                .Include(b => b.BookingSeats)
                .Include(b => b.Schedule)
                .FirstOrDefaultAsync(b => b.BookingID == bookingId);
        }

        public async Task<IEnumerable<Booking>> GetByUserIdAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserID == userId)
                .Include(b => b.BookingSeats)
                .ToListAsync();
        }

        public async Task<bool> CancelAsync(Booking booking)
        {
            booking.Status = "CANCELLED";
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
