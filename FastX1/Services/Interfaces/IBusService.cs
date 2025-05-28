using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface IBusService
    {
        Task<Bus> AddBusAsync(Bus bus);
        Task<List<Bus>> GetAllBusesAsync();
        Task<List<Bus>> GetBusesByOperatorAsync(int operatorId);
        Task<Bus> GetBusByIdAsync(int busId);
    }
}
