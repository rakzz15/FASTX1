using FastX1.Data;
using FastX1.Models;
using FastX1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using FastX1.Repositories.Interfaces;

namespace FastX1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterAsync(User user)
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser != null)
                throw new Exception("Email already registered.");

            user.CreatedAt = DateTime.Now;
            return await _userRepository.AddAsync(user);
        }

        public async Task<User> LoginAsync(string email, string passwordHash)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || user.PasswordHash != passwordHash)
                throw new Exception("Invalid email or password.");

            return user;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }
    }
}
