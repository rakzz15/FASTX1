using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface ISeatService
    {
        Task<List<Seat>> GetSeatsByScheduleIdAsync(int scheduleId);
        Task<List<Seat>> GetAvailableSeatsAsync(int scheduleId);
        Task<bool> MarkSeatAsBookedAsync(int seatId);
        Task<bool> MarkSeatAsAvailableAsync(int seatId);
    }
}
