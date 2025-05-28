using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Repositories.Implementations
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FastXDbContext _context;

        public FeedbackRepository(FastXDbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<IEnumerable<Feedback>> GetByRouteIdAsync(int routeId)
        {
            return await _context.Feedbacks
                .Where(f => f.RouteID == routeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByUserIdAsync(int userId)
        {
            return await _context.Feedbacks
                .Where(f => f.UserID == userId)
                .ToListAsync();
        }
    }
}
