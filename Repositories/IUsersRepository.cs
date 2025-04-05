using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories;

public interface IUsersRepository
{
    Task<User?> GetUserByIdAsync(string id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<List<User>> GetAllUsersAsync();
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<User?> GetUserAsync(ClaimsPrincipal user);
    Task<IdentityResult> UpdateUserAsync(User user);
    Task<IdentityResult> UpdateImageAsync(string userId, string imagePath);
    Task<IdentityResult> DeleteImageAsync(string userId);
    Task<List<User>> GetUserSuggestionsAsync(string userId, int count = 10);
}
