using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Repositories.Implementations
{
    public class BusRepository : IBusRepository
    {
        private readonly FastXDbContext _context;

        public BusRepository(FastXDbContext context)
        {
            _context = context;
        }

        public async Task<Bus> AddAsync(Bus bus)
        {
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();
            return bus;
        }

        public async Task<IEnumerable<Bus>> GetAllAsync()
        {
            return await _context.Buses.ToListAsync();
        }

        public async Task<IEnumerable<Bus>> GetByOperatorIdAsync(int operatorId)
        {
            return await _context.Buses
                .Where(b => b.OperatorID == operatorId)
                .ToListAsync();
        }

        public async Task<Bus> GetByIdAsync(int busId)
        {
            return await _context.Buses.FindAsync(busId);
        }
    }
}
