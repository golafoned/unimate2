using Microsoft.AspNetCore.Mvc;
using UniMate2.Models.Domain;
using UniMate2.Repositories;

namespace UniMate2.Controllers
{
    public class LikeController(IUsersRepository usersRepository, ILikeRepository likeRepository)
        : Controller
    {
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly ILikeRepository _likeRepository = likeRepository;

        public async Task<IActionResult> Create(string likedEmail)
        {
            if (!(User?.Identity?.IsAuthenticated ?? false))
            {
                return Unauthorized();
            }

            var currentUser = await _usersRepository.GetUserByEmailAsync(User.Identity.Name!);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            var likedUser = await _usersRepository.GetUserByEmailAsync(likedEmail);
            if (likedUser == null)
            {
                return NotFound($"User with email '{likedEmail}' not found.");
            }

            if (currentUser.Id == likedUser.Id)
            {
                return BadRequest("You cannot like yourself.");
            }

            var like = new Like
            {
                Id = Guid.NewGuid(),
                Liker = currentUser,
                Liked = likedUser,
                LikedAt = DateTime.UtcNow,
            };

            await _likeRepository.AddAsync(like);

            return Ok(new { message = "Like created successfully." });
        }
    }
}
