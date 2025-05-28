using FastX1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastX1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet("schedule/{scheduleId}")]
        public async Task<IActionResult> GetAllSeats(int scheduleId)
        {
            var seats = await _seatService.GetSeatsByScheduleIdAsync(scheduleId);
            return Ok(seats);
        }

        [HttpGet("available/{scheduleId}")]
        public async Task<IActionResult> GetAvailableSeats(int scheduleId)
        {
            var seats = await _seatService.GetAvailableSeatsAsync(scheduleId);
            return Ok(seats);
        }

        [HttpPut("book/{seatId}")]
        [Authorize]

        public async Task<IActionResult> BookSeat(int seatId)
        {
            var success = await _seatService.MarkSeatAsBookedAsync(seatId);
            return success ? Ok("Seat booked.") : BadRequest("Seat already booked or not found.");
        }

        [HttpPut("unbook/{seatId}")]
        [Authorize]

        public async Task<IActionResult> UnbookSeat(int seatId)
        {
            var success = await _seatService.MarkSeatAsAvailableAsync(seatId);
            return success ? Ok("Seat unbooked.") : BadRequest("Seat already free or not found.");
        }
    }
}
