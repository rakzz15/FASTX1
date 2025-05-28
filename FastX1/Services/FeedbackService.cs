using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using FastX1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Services { 
    public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepo;
    private readonly FastXDbContext _context;

    public FeedbackService(IFeedbackRepository feedbackRepo, FastXDbContext context)
    {
        _feedbackRepo = feedbackRepo;
        _context = context;
    }

    public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
    {
        var userExists = await _context.Users.AnyAsync(u => u.UserID == feedback.UserID);
        var routeExists = await _context.Routes.AnyAsync(r => r.RouteID == feedback.RouteID);

        if (!userExists || !routeExists)
            throw new Exception("User or Route does not exist.");

        feedback.SubmittedAt = DateTime.Now;
        return await _feedbackRepo.AddAsync(feedback);
    }

    public async Task<List<Feedback>> GetFeedbacksByRouteAsync(int routeId)
    {
        var feedbacks = await _feedbackRepo.GetByRouteIdAsync(routeId);
        return feedbacks.ToList();
    }

    public async Task<List<Feedback>> GetFeedbacksByUserAsync(int userId)
    {
        var feedbacks = await _feedbackRepo.GetByUserIdAsync(userId);
        return feedbacks.ToList();
    }
}
}