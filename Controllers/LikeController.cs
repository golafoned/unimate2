using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniMate2.Models.Domain;
using UniMate2.Repositories;

namespace UniMate2.Controllers
{
    [Authorize]
    public class LikeController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILikeRepository _likeRepository;

        public LikeController(IUsersRepository usersRepository, ILikeRepository likeRepository)
        {
            _usersRepository = usersRepository;
            _likeRepository = likeRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string likedUserId)
        {
            if (string.IsNullOrEmpty(likedUserId))
            {
                return BadRequest("Liked user ID is required");
            }

            var currentUserId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier
            )?.Value;
            if (currentUserId == null)
            {
                return Unauthorized();
            }

            if (currentUserId == likedUserId)
            {
                return BadRequest("You cannot like yourself.");
            }

            // Check if already liked
            if (await _likeRepository.LikeExistsAsync(currentUserId, likedUserId))
            {
                return Ok(new { message = "Already liked this user." });
            }

            var currentUser = await _usersRepository.GetUserByIdAsync(currentUserId);
            var likedUser = await _usersRepository.GetUserByIdAsync(likedUserId);

            if (currentUser == null || likedUser == null)
            {
                return NotFound("User not found");
            }

            var like = new Like
            {
                Id = Guid.NewGuid(),
                Liker = currentUser,
                LikerId = currentUserId,
                Liked = likedUser,
                LikedId = likedUserId,
                LikedAt = DateTime.UtcNow,
            };

            await _likeRepository.AddAsync(like);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = true });
            }

            return RedirectToAction("Suggestions", "Users");
        }
    }
}
