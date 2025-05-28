using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Repositories.Implementations
{

        public class BusRouteRepository : IBusRouteRepository
        {
            private readonly FastXDbContext _context;

            public BusRouteRepository(FastXDbContext context)
            {
                _context = context;
            }

            public async Task<BusRoute> AddAsync(BusRoute route)
            {
                _context.Routes.Add(route);
                await _context.SaveChangesAsync();
                return route;
            }

            public async Task<IEnumerable<BusRoute>> GetAllAsync()
            {
                return await _context.Routes.ToListAsync();
            }

            public async Task<IEnumerable<BusRoute>> GetByBusIdAsync(int busId)
            {
                return await _context.Routes
                    .Where(r => r.BusID == busId)
                    .ToListAsync();
            }

            public async Task<BusRoute> GetByIdAsync(int routeId)
            {
                return await _context.Routes.FindAsync(routeId);
            }
        }
    }

