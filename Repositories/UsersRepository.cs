using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using UniMate2.Data;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ServerDbContext _context;

        public UsersRepository(UserManager<User> userManager, ServerDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<User?> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            // Include the Images collection when fetching the user
            return await _userManager
                .Users.Include(u => u.Images)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            // Include the Images collection when fetching the user
            return await _userManager
                .Users.Include(u => u.Images)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            // Include the Images collection when fetching all users
            return await _userManager.Users.Include(u => u.Images).ToListAsync();
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> UpdateImageAsync(string userId, string imagePath)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            if (user.Images == null)
            {
                user.Images = new List<UserImage>();
            }

            // Add new image
            var userImage = new UserImage
            {
                Id = Guid.NewGuid(),
                User = user,
                ImagePath = imagePath,
                SerialNumber = user.Images.Count,
            };

            user.Images.Add(userImage);

            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteImageAsync(string userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            // Remove all images (or you could modify to remove specific images)
            if (user.Images != null)
            {
                user.Images.Clear();
            }

            return await _userManager.UpdateAsync(user);
        }

        public async Task<List<User>> GetUserSuggestionsAsync(string userId, int count = 10)
        {
            // Get the current user
            var currentUser = await _userManager.FindByIdAsync(userId);
            if (currentUser == null)
            {
                return new List<User>();
            }

            // Get users who are not friends and not pending friends
            // First get IDs of users who already have a friendship connection
            var friendRequestUserIds = await _context
                .FriendRequests.Where(fr => fr.Sender.Id == userId || fr.Receiver.Id == userId)
                .Select(fr => fr.Sender.Id == userId ? fr.Receiver.Id : fr.Sender.Id)
                .ToListAsync();

            // Then get users who are not in that list and not the current user
            var suggestions = await _userManager
                .Users.Where(u => u.Id != userId && !friendRequestUserIds.Contains(u.Id))
                .Take(count)
                .ToListAsync();

            return suggestions;
        }
    }
}
