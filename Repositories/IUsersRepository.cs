using Microsoft.AspNetCore.Identity;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories;

public interface IUsersRepository
{
    Task<User?> GetUserByIdAsync(string id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<List<User>> GetAllUsersAsync();
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<IdentityResult> UpdateUserAsync(User user);
}
