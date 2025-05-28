using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface IBusScheduleRepository
    {
        Task<BusSchedule> AddAsync(BusSchedule schedule);
        Task<List<BusSchedule>> GetAllAsync();
        Task<List<BusSchedule>> GetByRouteIdAsync(int routeId);
    }
}
