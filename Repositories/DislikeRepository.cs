using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public class DislikeRepository : IDislikeRepository
    {
        private readonly ServerDbContext _context;
        private readonly UserManager<User> _userManager;

        public DislikeRepository(ServerDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<UserDislike?> GetDislikeAsync(Guid id)
        {
            return await _context.UserDislikes.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<UserDislike>> GetAllDislikesAsync()
        {
            return await _context
                .UserDislikes.OrderBy(d => d.CreatedAt) // Add ordering for predictability
                .ToListAsync();
        }

        public async Task<List<string>> GetDislikedUserIdsAsync(string userId)
        {
            return await _context
                .UserDislikes.Where(ud => ud.DislikingUserId == userId)
                .Select(ud => ud.DislikedUserId)
                .ToListAsync();
        }

        public async Task<List<string>> GetUsersWhoDislikedMeIdsAsync(string userId)
        {
            return await _context
                .UserDislikes.Where(ud => ud.DislikedUserId == userId)
                .Select(ud => ud.DislikingUserId)
                .ToListAsync();
        }

        public async Task AddAsync(UserDislike dislike)
        {
            await _context.UserDislikes.AddAsync(dislike);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DislikeExistsAsync(string dislikerId, string dislikedId)
        {
            return await _context.UserDislikes.AnyAsync(d =>
                d.DislikingUserId == dislikerId && d.DislikedUserId == dislikedId
            );
        }

        public async Task<bool> CreateDislikeAsync(string dislikingUserId, string dislikedUserId)
        {
            // Check if already disliked
            if (await DislikeExistsAsync(dislikingUserId, dislikedUserId))
            {
                return false; // Already disliked
            }

            // Get users
            var dislikingUser = await _userManager.FindByIdAsync(dislikingUserId);
            var dislikedUser = await _userManager.FindByIdAsync(dislikedUserId);

            if (dislikingUser == null || dislikedUser == null)
            {
                return false;
            }

            // Create dislike - ensuring DateTime is UTC
            var dislike = new UserDislike
            {
                Id = Guid.NewGuid(),
                DislikingUser = dislikingUser,
                DislikingUserId = dislikingUserId,
                DislikedUser = dislikedUser,
                DislikedUserId = dislikedUserId,
                CreatedAt = DateTime.UtcNow, // This explicitly uses UTC time
            };

            await AddAsync(dislike);
            return true;
        }

        public async Task<List<UserDislike>> GetUserDislikesWithDetailsAsync(string userId)
        {
            return await _context
                .UserDislikes.Include(d => d.DislikedUser)
                .ThenInclude(u => u.Images)
                .Where(d => d.DislikingUserId == userId)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<UserDislike>> GetDislikesReceivedWithDetailsAsync(string userId)
        {
            return await _context
                .UserDislikes.Include(d => d.DislikingUser)
                .ThenInclude(u => u.Images)
                .Where(d => d.DislikedUserId == userId)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }
    }
}
