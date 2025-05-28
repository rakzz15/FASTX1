using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface IBusRepository
    {
        Task<Bus> AddAsync(Bus bus);
        Task<IEnumerable<Bus>> GetAllAsync();
        Task<IEnumerable<Bus>> GetByOperatorIdAsync(int operatorId);
        Task<Bus> GetByIdAsync(int busId);

    }
}
