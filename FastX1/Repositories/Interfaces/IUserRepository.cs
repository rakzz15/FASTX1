﻿using FastX1.Models;

namespace FastX1.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
    }
}
