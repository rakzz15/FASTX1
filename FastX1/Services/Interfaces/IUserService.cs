using FastX1.Models;

namespace FastX1.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(string email, string passwordHash);
        Task<User> GetUserByIdAsync(int userId);
    }
}
