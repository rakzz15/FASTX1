using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface IBusRouteRepository
    {
        Task<BusRoute> AddAsync(BusRoute route);
        Task<IEnumerable<BusRoute>> GetAllAsync();
        Task<IEnumerable<BusRoute>> GetByBusIdAsync(int busId);
        Task<BusRoute> GetByIdAsync(int routeId);
    }
}
