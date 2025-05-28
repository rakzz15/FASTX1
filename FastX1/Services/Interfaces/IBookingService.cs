using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<Seat>> GetAvailableSeatsAsync(int scheduleId);
        Task<Booking> CreateBookingAsync(int userId, int scheduleId, List<string> seatNumbers);
        Task<bool> CancelBookingAsync(int bookingId, string reason);
    }
}
