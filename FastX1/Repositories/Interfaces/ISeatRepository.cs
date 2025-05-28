using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetByScheduleIdAsync(int scheduleId);
        Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int scheduleId);
        Task<Seat> GetByIdAsync(int seatId);
        Task UpdateAsync(Seat seat);
    }
}
