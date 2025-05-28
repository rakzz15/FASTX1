namespace FastX1.Services;
using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using FastX1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        private readonly FastXDbContext _context; // For BusOperator check only

        public BusService(IBusRepository busRepository, FastXDbContext context)
        {
            _busRepository = busRepository;
            _context = context;
        }

        public async Task<Bus> AddBusAsync(Bus bus)
        {
            var operatorExists = await _context.BusOperators
                .AnyAsync(o => o.OperatorID == bus.OperatorID);

            if (!operatorExists)
                throw new Exception("Bus operator does not exist.");

            return await _busRepository.AddAsync(bus);
        }

        public async Task<List<Bus>> GetAllBusesAsync()
        {
            var buses = await _busRepository.GetAllAsync();
            return buses.ToList(); // Cast from IEnumerable<Bus> to List<Bus>
        }

        public async Task<List<Bus>> GetBusesByOperatorAsync(int operatorId)
        {
            var buses = await _busRepository.GetByOperatorIdAsync(operatorId);
            return buses.ToList();
        }

        public async Task<Bus> GetBusByIdAsync(int busId)
        {
            return await _busRepository.GetByIdAsync(busId);
        }
    }
