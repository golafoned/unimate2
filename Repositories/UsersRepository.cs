using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ServerDbContext _context;
        private readonly IDislikeRepository _dislikeRepository;
        private readonly ILikeRepository _likeRepository;

        public UsersRepository(
            UserManager<User> userManager,
            ServerDbContext context,
            IDislikeRepository dislikeRepository,
            ILikeRepository likeRepository
        )
        {
            _userManager = userManager;
            _context = context;
            _dislikeRepository = dislikeRepository;
            _likeRepository = likeRepository;
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
                user.Images = [];
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
                return [];
            }

            // Get users who are not friends and not pending friends
            // First get IDs of users who already have a friendship connection
            var friendRequestUserIds = await _context
                .FriendRequests.Where(fr => fr.Sender.Id == userId || fr.Receiver.Id == userId)
                .Select(fr => fr.Sender.Id == userId ? fr.Receiver.Id : fr.Sender.Id)
                .ToListAsync();

            // Get IDs of disliked users
            var dislikedUserIds = await _context
                .UserDislikes.Where(ud => ud.DislikingUserId == userId)
                .Select(ud => ud.DislikedUserId)
                .ToListAsync();

            // Get IDs of users who disliked the current user
            var usersWhoDislikedMeIds = await _context
                .UserDislikes.Where(ud => ud.DislikedUserId == userId)
                .Select(ud => ud.DislikingUserId)
                .ToListAsync();

            // Get IDs of liked users (if you have a Likes table)
            var likedUserIds = await _context
                .Likes.Where(l => l.LikerId == userId)
                .Select(l => l.LikedId)
                .ToListAsync();

            // Combine all IDs to exclude
            var excludedUserIds = new List<string>();
            excludedUserIds.AddRange(friendRequestUserIds);
            excludedUserIds.AddRange(dislikedUserIds);
            excludedUserIds.AddRange(usersWhoDislikedMeIds);
            excludedUserIds.AddRange(likedUserIds);
            excludedUserIds = excludedUserIds.Distinct().ToList();

            // Include the Images collection when fetching users
            var suggestions = await _userManager
                .Users.Include(u => u.Images)
                .Where(u => u.Id != userId && !excludedUserIds.Contains(u.Id))
                .OrderBy(u => u.FirstName) // Add ordering to make results predictable
                .Take(count)
                .ToListAsync();

            return suggestions;
        }

        public async Task<List<User>> SearchUsersAsync(
            string userId,
            string searchTerm,
            int count = 20
        )
        {
            // Get the current user
            var currentUser = await _userManager.FindByIdAsync(userId);
            if (currentUser == null || string.IsNullOrWhiteSpace(searchTerm))
            {
                return [];
            }

            // Get IDs of users who already have a friendship connection
            var friendRequestUserIds = await _context
                .FriendRequests.Where(fr => fr.Sender.Id == userId || fr.Receiver.Id == userId)
                .Select(fr => fr.Sender.Id == userId ? fr.Receiver.Id : fr.Sender.Id)
                .ToListAsync();

            // Get IDs of disliked users
            var dislikedUserIds = await _context
                .UserDislikes.Where(ud => ud.DislikingUserId == userId)
                .Select(ud => ud.DislikedUserId)
                .ToListAsync();

            // Search for users by name or email
            var searchTermLower = searchTerm.ToLower();
            var users = await _userManager
                .Users.Where(u => u.Id != userId)
                .Where(u => !friendRequestUserIds.Contains(u.Id))
                .Where(u => !dislikedUserIds.Contains(u.Id))
                .Where(u =>
                    (u.Email != null && u.Email.ToLower().Contains(searchTermLower))
                    || (u.FirstName != null && u.FirstName.ToLower().Contains(searchTermLower))
                    || (u.LastName != null && u.LastName.ToLower().Contains(searchTermLower))
                )
                .Take(count)
                .ToListAsync();

            return users;
        }
    }
}
