using FastX1.Models;
using FastX1.Repositories.Interfaces;
using FastX1.Services.Interfaces;

public class BusScheduleService : IBusScheduleService
{
    private readonly IBusScheduleRepository _repository;

    public BusScheduleService(IBusScheduleRepository repository)
    {
        _repository = repository;
    }

    public Task<BusSchedule> AddScheduleAsync(BusSchedule schedule)
        => _repository.AddAsync(schedule);

    public Task<List<BusSchedule>> GetAllSchedulesAsync()
        => _repository.GetAllAsync();

    public Task<List<BusSchedule>> GetByRouteIdAsync(int routeId)
        => _repository.GetByRouteIdAsync(routeId);
}
