using FastX1.Models;
using FastX1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FastX1.Models.DTOs.Payment;
using Microsoft.AspNetCore.Authorization;

namespace FastX1.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("add")]
        [Authorize]

        public async Task<IActionResult> AddPayment([FromBody] PaymentRequest request)
        {
            try
            {
                var payment = new Payment
                {
                    BookingID = request.BookingID,
                    Amount = request.Amount,
                    PaymentMethod = request.PaymentMethod,
                    PaymentDate = DateTime.Now,
                    PaymentStatus = "SUCCESS" // or derive from business logic
                };

                var addedPayment = await _paymentService.AddPaymentAsync(payment);

                var response = new PaymentResponse
                {
                    PaymentID = addedPayment.PaymentID,
                    BookingID = addedPayment.BookingID,
                    Amount = addedPayment.Amount,
                    PaymentDate = addedPayment.PaymentDate,
                    PaymentMethod = addedPayment.PaymentMethod,
                    PaymentStatus = addedPayment.PaymentStatus
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("booking/{bookingId}")]
        public async Task<IActionResult> GetPaymentByBookingId(int bookingId)
        {
            var payment = await _paymentService.GetPaymentByBookingIdAsync(bookingId);
            if (payment == null) return NotFound();

            var response = new PaymentResponse
            {
                PaymentID = payment.PaymentID,
                BookingID = payment.BookingID,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus
            };

            return Ok(response);
        }
    }
}
