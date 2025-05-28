using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Repositories.Implementations
{

    public class SeatRepository : ISeatRepository
    {
        private readonly FastXDbContext _context;

        public SeatRepository(FastXDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetByScheduleIdAsync(int scheduleId)
        {
            return await _context.Seats
                .Where(s => s.ScheduleID == scheduleId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int scheduleId)
        {
            return await _context.Seats
                .Where(s => s.ScheduleID == scheduleId && !s.IsBooked)
                .ToListAsync();
        }

        public async Task<Seat> GetByIdAsync(int seatId)
        {
            return await _context.Seats.FindAsync(seatId);
        }

        public async Task UpdateAsync(Seat seat)
        {
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync();
        }
    }
}
