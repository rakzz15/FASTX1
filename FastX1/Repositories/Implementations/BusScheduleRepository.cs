using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Repositories.Implementations
{
    public class BusScheduleRepository : IBusScheduleRepository
    {
        private readonly FastXDbContext _context;

        public BusScheduleRepository(FastXDbContext context)
        {
            _context = context;
        }

        public async Task<BusSchedule> AddAsync(BusSchedule schedule)
        {
            _context.BusSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<List<BusSchedule>> GetAllAsync()
        {
            return await _context.BusSchedules
                .Include(s => s.Route)
                .ToListAsync();
        }

        public async Task<List<BusSchedule>> GetByRouteIdAsync(int routeId)
        {
            return await _context.BusSchedules
                .Where(s => s.RouteID == routeId)
                .Include(s => s.Route)
                .ToListAsync();
        }
    }
}
