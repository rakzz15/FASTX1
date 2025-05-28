using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<Feedback> AddFeedbackAsync(Feedback feedback);
        Task<List<Feedback>> GetFeedbacksByRouteAsync(int routeId);
        Task<List<Feedback>> GetFeedbacksByUserAsync(int userId);
    }
}
