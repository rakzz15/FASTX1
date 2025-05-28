using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface IBusOperatorRepository
    {
        Task<BusOperator> AddAsync(BusOperator op);
        Task<IEnumerable<BusOperator>> GetAllAsync();
        Task<BusOperator> GetByIdAsync(int id);
        Task<BusOperator> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(int operatorId);
    }
}
