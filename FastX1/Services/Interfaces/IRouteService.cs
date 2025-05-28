using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface IRouteService
    {
        Task<BusRoute> AddRouteAsync(BusRoute route);
        Task<List<Route>> GetAllRoutesAsync();
        Task<List<Route>> GetRoutesByBusIdAsync(int busId);
        Task<Route> GetRouteByIdAsync(int routeId);
    }
}
