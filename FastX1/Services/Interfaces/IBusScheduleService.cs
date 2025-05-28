using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface IBusScheduleService
    {
        Task<BusSchedule> AddScheduleAsync(BusSchedule schedule);
        Task<List<BusSchedule>> GetAllSchedulesAsync();
        Task<List<BusSchedule>> GetByRouteIdAsync(int routeId);
    }
}
