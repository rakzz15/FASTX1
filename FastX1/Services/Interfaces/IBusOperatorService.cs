using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface IBusOperatorService
    {
        Task<BusOperator> RegisterOperatorAsync(BusOperator operatorData);
        Task<List<BusOperator>> GetAllOperatorsAsync();
        Task<BusOperator> GetOperatorByIdAsync(int operatorId);
    }
}
