using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback> AddAsync(Feedback feedback);
        Task<IEnumerable<Feedback>> GetByRouteIdAsync(int routeId);
        Task<IEnumerable<Feedback>> GetByUserIdAsync(int userId);
    }
}
