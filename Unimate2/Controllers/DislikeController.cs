using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniMate2.Repositories;

namespace UniMate2.Controllers
{
    [Authorize]
    public class DislikeController : Controller
    {
        private readonly IDislikeRepository _dislikeRepository;
        private readonly ILogger<DislikeController> _logger;

        public DislikeController(
            IDislikeRepository dislikeRepository,
            ILogger<DislikeController> logger
        )
        {
            _dislikeRepository = dislikeRepository;
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string dislikedUserId)
        {
            try
            {
                var userId = User.FindFirst(
                    System.Security.Claims.ClaimTypes.NameIdentifier
                )?.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }

                if (string.IsNullOrEmpty(dislikedUserId))
                {
                    return BadRequest("Disliked user ID is required");
                }

                var success = await _dislikeRepository.CreateDislikeAsync(userId, dislikedUserId);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success });
                }

                return RedirectToAction("Suggestions", "Users");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error creating dislike for user {DislikedUserId}",
                    dislikedUserId
                );

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, error = ex.Message });
                }

                ModelState.AddModelError("", "An error occurred while disliking the user.");
                return RedirectToAction("Suggestions", "Users");
            }
        }
    }
}
