using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> AddPaymentAsync(Payment payment);
        Task<Payment> GetPaymentByBookingIdAsync(int bookingId);
    }
}
