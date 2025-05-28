using FastX1.Models;
using FastX1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FastX1.Models.DTOs.Feedback;
using Microsoft.AspNetCore.Authorization;

namespace FastX1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("add")]
        [Authorize]

        public async Task<IActionResult> AddFeedback([FromBody] FeedbackRequest request)
        {
            try
            {
                var feedback = new Feedback
                {
                    UserID = request.UserID,
                    RouteID = request.RouteID,
                    Rating = request.Rating,
                    Comments = request.Comments,
                    SubmittedAt = DateTime.Now
                };

                var result = await _feedbackService.AddFeedbackAsync(feedback);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("route/{routeId}")]
        public async Task<IActionResult> GetFeedbacksByRoute(int routeId)
        {
            var feedbacks = await _feedbackService.GetFeedbacksByRouteAsync(routeId);
            return Ok(feedbacks);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFeedbacksByUser(int userId)
        {
            var feedbacks = await _feedbackService.GetFeedbacksByUserAsync(userId);
            return Ok(feedbacks);
        }
    }

}