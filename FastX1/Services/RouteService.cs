using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using FastX1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using BusRoute = FastX1.Models.BusRoute;

namespace FastX1.Services
{
    public class RouteService : IRouteService
    {
        private readonly IBusRouteRepository _routeRepository;
        private readonly FastXDbContext _context; // still used for checking bus existence

        public RouteService(IBusRouteRepository routeRepository, FastXDbContext context)
        {
            _routeRepository = routeRepository;
            _context = context;
        }

        public async Task<BusRoute> AddRouteAsync(BusRoute route)
        {
            var busExists = await _context.Buses.AnyAsync(b => b.BusID == route.BusID);
            if (!busExists)
                throw new Exception("Bus does not exist.");

            return await _routeRepository.AddAsync(route);
        }

        public async Task<List<BusRoute>> GetAllRoutesAsync()
        {
            var routes = await _routeRepository.GetAllAsync();
            return routes.ToList();
        }

        public async Task<List<BusRoute>> GetRoutesByBusIdAsync(int busId)
        {
            var routes = await _routeRepository.GetByBusIdAsync(busId);
            return routes.ToList();
        }

        public async Task<BusRoute> GetRouteByIdAsync(int routeId)
        {
            return await _routeRepository.GetByIdAsync(routeId);
        }
        public Task<Microsoft.AspNetCore.Routing.Route> AddRouteAsync(Microsoft.AspNetCore.Routing.Route route)
        {
            throw new NotImplementedException();
        }

        Task<List<Microsoft.AspNetCore.Routing.Route>> IRouteService.GetAllRoutesAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<Microsoft.AspNetCore.Routing.Route>> IRouteService.GetRoutesByBusIdAsync(int busId)
        {
            throw new NotImplementedException();
        }

        Task<Microsoft.AspNetCore.Routing.Route> IRouteService.GetRouteByIdAsync(int routeId)
        {
            throw new NotImplementedException();
        }
    }
}