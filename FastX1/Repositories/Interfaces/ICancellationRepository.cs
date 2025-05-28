using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface ICancellationRepository
    {
        Task<CancellationLog> AddAsync(CancellationLog log);

    }
}
