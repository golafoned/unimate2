using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ServerDbContext _context;
        private readonly UserManager<User> _userManager;

        public LikeRepository(ServerDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Like?> GetLikeAsync(Guid id)
        {
            return await _context.Likes.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Like>> GetAllLikesAsync()
        {
            return await _context
                .Likes.OrderBy(l => l.LikedAt) // Add ordering for predictability
                .ToListAsync();
        }

        public async Task<List<string>> GetLikedUserIdsAsync(string userId)
        {
            return await _context
                .Likes.Where(l => l.LikerId == userId)
                .Select(l => l.LikedId)
                .ToListAsync();
        }

        public async Task AddAsync(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Like like)
        {
            _context.Likes.Update(like);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Like like)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> LikeExistsAsync(string likerId, string likedId)
        {
            return await _context.Likes.AnyAsync(l => l.LikerId == likerId && l.LikedId == likedId);
        }

        public async Task<List<Like>> GetUserLikesWithDetailsAsync(string userId)
        {
            return await _context
                .Likes.Include(l => l.Liked)
                .ThenInclude(u => u.Images)
                .Where(l => l.LikerId == userId)
                .OrderByDescending(l => l.LikedAt)
                .ToListAsync();
        }

        public async Task<List<Like>> GetLikesReceivedWithDetailsAsync(string userId)
        {
            return await _context
                .Likes.Include(l => l.Liker)
                .ThenInclude(u => u.Images)
                .Where(l => l.LikedId == userId)
                .OrderByDescending(l => l.LikedAt)
                .ToListAsync();
        }

        public async Task<List<string>> GetUsersWhoLikedMeIdsAsync(string userId)
        {
            return await _context
                .Likes.Where(l => l.LikedId == userId)
                .Select(l => l.LikerId)
                .ToListAsync();
        }

        public async Task<bool> CreateLikeAsync(string likingUserId, string likedUserId)
        {
            // Check if like already exists
            if (await LikeExistsAsync(likingUserId, likedUserId))
            {
                return false;
            }

            var like = new Like
            {
                LikerId = likingUserId,
                LikedId = likedUserId,
                LikedAt = DateTime.UtcNow,
            };

            await AddAsync(like);
            return true;
        }
    }
}
