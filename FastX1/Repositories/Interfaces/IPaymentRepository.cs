using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> AddAsync(Payment payment);
        Task<Payment> GetByBookingIdAsync(int bookingId);
    }
}
