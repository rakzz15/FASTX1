using FastX1.Models.DTOs.Booking;
using FastX1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastX1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("available-seats/{scheduleId}")]
        public async Task<IActionResult> GetAvailableSeats(int scheduleId)
        {
            var seats = await _bookingService.GetAvailableSeatsAsync(scheduleId);
            return Ok(seats);
        }

        [HttpPost("create")]

        [Authorize]

        public async Task<IActionResult> CreateBooking([FromBody] BookingRequest request)
        {
            try
            {
                var booking = await _bookingService.CreateBookingAsync(request.UserID, request.ScheduleID, request.SeatNumbers);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cancel/{bookingId}")]
        [Authorize]

        public async Task<IActionResult> CancelBooking(int bookingId, [FromBody] CancelRequest cancel)
        {
            var result = await _bookingService.CancelBookingAsync(bookingId, cancel.Reason);
            if (result)
                return Ok("Booking cancelled successfully.");
            else
                return NotFound("Booking not found or already cancelled.");
        }
    }
}
