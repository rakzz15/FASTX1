using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> AddAsync(Booking booking);
        Task<Booking> GetByIdAsync(int bookingId);
        Task<IEnumerable<Booking>> GetByUserIdAsync(int userId);
        Task<bool> CancelAsync(Booking booking);
    }
}
