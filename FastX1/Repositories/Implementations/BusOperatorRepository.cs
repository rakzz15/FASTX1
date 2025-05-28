using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Repositories.Implementations
{
    public class BusOperatorRepository : IBusOperatorRepository
    {
        private readonly FastXDbContext _context;

        public BusOperatorRepository(FastXDbContext context)
        {
            _context = context;
        }

        public async Task<BusOperator> AddAsync(BusOperator op)
        {
            _context.BusOperators.Add(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<IEnumerable<BusOperator>> GetAllAsync()
        {
            return await _context.BusOperators.ToListAsync();
        }

        public async Task<BusOperator> GetByIdAsync(int id)
        {
            return await _context.BusOperators.FindAsync(id);
        }

        public async Task<BusOperator> GetByEmailAsync(string email)
        {
            return await _context.BusOperators
                .FirstOrDefaultAsync(o => o.Email == email);
        }

        public async Task<bool> ExistsAsync(int operatorId)
        {
            return await _context.BusOperators.AnyAsync(o => o.OperatorID == operatorId);
        }
    }
}
