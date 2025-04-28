using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using UniMate2.Data;
using UniMate2.Models.Domain;
using UniMate2.Models.ViewModels.Admin;
using UniMate2.Repositories;


namespace UniMate2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IEventsRepository _eventsRepository;
        private readonly ILogger<AdminController> _logger;
        private readonly ILikeRepository _likeRepository;
        private readonly IDislikeRepository _dislikeRepository;
        private readonly IFriendsRepository _friendsRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ServerDbContext _context;


        public AdminController(
            IUsersRepository usersRepository,
            IEventsRepository eventsRepository,
            ILogger<AdminController> logger,
            ILikeRepository likeRepository,
            IDislikeRepository dislikeRepository,
            IFriendsRepository friendsRepository,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ServerDbContext context
        )
        {
            _usersRepository = usersRepository;
            _eventsRepository = eventsRepository;
            _logger = logger;
            _likeRepository = likeRepository;
            _dislikeRepository = dislikeRepository;
            _friendsRepository = friendsRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: Admin/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var dashboardViewModel = new AdminDashboardViewModel
            {
                TotalUsers = _userManager.Users.Count(),
                TotalEvents = (await _eventsRepository.GetAllEvents()).Count,
                TotalLikes = await _likeRepository.GetTotalLikesCountAsync(),
                TotalDislikes = await _dislikeRepository.GetTotalDislikesCountAsync(),
                TotalFriendRequests = await _friendsRepository.GetTotalFriendRequestsCountAsync(),
            };

            return View(dashboardViewModel);
        }

        // GET: Admin/Users
        public async Task<IActionResult> Users(string sortOrder = "none")
        {
            List<User> users;
            var viewModel = new UsersViewModel { SortOrder = sortOrder };

            switch (sortOrder)
            {
                case "likesReceived":
                    users = await _usersRepository.GetUsersOrderedByLikesReceivedAsync();
                    viewModel.LikesReceived =
                        await _usersRepository.GetUserLikesReceivedCountAsync();
                    break;
                case "likesGiven":
                    users = await _usersRepository.GetUsersOrderedByLikesGivenAsync();
                    viewModel.LikesGiven = await _usersRepository.GetUserLikesGivenCountAsync();
                    break;
                default:
                    users = await _usersRepository.GetAllUsersAsync();
                    break;
            }

            viewModel.Users = users;

            // If we're sorting by likes, make sure we have the counts for display
            if (sortOrder == "none")
            {
                viewModel.LikesReceived = await _usersRepository.GetUserLikesReceivedCountAsync();
                viewModel.LikesGiven = await _usersRepository.GetUserLikesGivenCountAsync();
            }

            return View(viewModel);
        }

        // GET: Admin/EditUser
        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogWarning("Edit user attempt with null or empty ID");
                TempData["ErrorMessage"] = "User ID is required.";
                return RedirectToAction(nameof(Users));
            }

            var user = await _usersRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User not found for ID: {UserId}", id);
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction(nameof(Users));
            }

            // Get user roles
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            var viewModel = new EditUserViewModel
            {
                User = user,
                UserRoles = userRoles?.ToList() ?? new List<string>(),
                AllRoles = allRoles.Where(r => r != null).Cast<string>().ToList(),
            };

            return View(viewModel);
        }

        // POST: Admin/UpdateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(
            string id,
            User updatedUser,
            List<string> selectedRoles
        )
        {
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogWarning("Update user attempt with null or empty ID");
                TempData["ErrorMessage"] = "User ID is required.";
                return RedirectToAction(nameof(Users));
            }

            var user = await _usersRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User not found for ID: {UserId}", id);
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction(nameof(Users));
            }

            // Update user properties
            user.Email = updatedUser.Email;
            user.UserName = updatedUser.Email;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.University = updatedUser.University;
            user.Faculty = updatedUser.Faculty;
            user.Gender = updatedUser.Gender;
            user.Orientation = updatedUser.Orientation;
            user.IsSmoking = updatedUser.IsSmoking;
            user.IsDrinking = updatedUser.IsDrinking;
            user.LookingFor = updatedUser.LookingFor;
            user.Bio = updatedUser.Bio;

            // Update user in database
            var updateResult = await _usersRepository.UpdateUserAsync(user);
            if (!updateResult.Succeeded)
            {
                _logger.LogError("Failed to update user: {UserId}", id);
                TempData["ErrorMessage"] = "Failed to update user information.";
                return RedirectToAction(nameof(EditUser), new { id });
            }

            // Update roles
            var currentRoles = await _userManager.GetRolesAsync(user);

            // Remove roles that are not in the selected roles
            foreach (var role in currentRoles)
            {
                if (!selectedRoles.Contains(role))
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }

            // Add roles that are selected but not current
            foreach (var role in selectedRoles)
            {
                if (!currentRoles.Contains(role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            _logger.LogInformation("User {UserId} updated successfully by admin", id);
            TempData["SuccessMessage"] = "User updated successfully.";
            return RedirectToAction(nameof(Users));
        }

        // POST: Admin/DeleteUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("Delete user attempt with null or empty ID");
                TempData["ErrorMessage"] = "User ID is required.";
                return RedirectToAction(nameof(Users));
            }

            _logger.LogInformation("Admin attempting to delete user with ID: {UserId}", userId);

            var result = await _usersRepository.DeleteUserAsync(userId);
            if (!result.Succeeded)
            {
                _logger.LogError(
                    "Failed to delete user: {UserId}, Errors: {Errors}",
                    userId,
                    string.Join(", ", result.Errors.Select(e => e.Description))
                );

                TempData["ErrorMessage"] =
                    "Failed to delete user: "
                    + string.Join(", ", result.Errors.Select(e => e.Description));

                return RedirectToAction(nameof(Users));
            }

            _logger.LogInformation("User {UserId} deleted successfully by admin", userId);
            TempData["SuccessMessage"] = "User deleted successfully.";
            return RedirectToAction(nameof(Users));
        }

        // GET: Admin/Events
        public async Task<IActionResult> Events()
        {
            var events = await _eventsRepository.GetAllEvents();
            return View(events);
        }

        // GET: Admin/EditEvent
        public async Task<IActionResult> EditEvent(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("Edit event attempt with empty GUID");
                TempData["ErrorMessage"] = "Valid Event ID is required.";
                return RedirectToAction(nameof(Events));
            }

            var eventToEdit = await _eventsRepository.GetEventById(id);
            if (eventToEdit == null)
            {
                _logger.LogWarning("Event not found for ID: {EventId}", id);
                TempData["ErrorMessage"] = "Event not found.";
                return RedirectToAction(nameof(Events));
            }

            return View(eventToEdit);
        }

        // POST: Admin/UpdateEvent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEvent(Event updatedEvent)
        {
            if (!ModelState.IsValid)
            {
                return View("EditEvent", updatedEvent);
            }

            var result = await _eventsRepository.UpdateEvent(updatedEvent);
            if (!result)
            {
                _logger.LogError("Failed to update event: {EventId}", updatedEvent.Id);
                TempData["ErrorMessage"] = "Failed to update event.";
                return View("EditEvent", updatedEvent);
            }

            _logger.LogInformation(
                "Event {EventId} updated successfully by admin",
                updatedEvent.Id
            );
            TempData["SuccessMessage"] = "Event updated successfully.";
            return RedirectToAction(nameof(Events));
        }

        // POST: Admin/DeleteEvent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEvent(Guid eventId)
        {
            if (eventId == Guid.Empty)
            {
                _logger.LogWarning("Delete event attempt with empty GUID");
                TempData["ErrorMessage"] = "Valid Event ID is required.";
                return RedirectToAction(nameof(Events));
            }

            _logger.LogInformation("Admin attempting to delete event with ID: {EventId}", eventId);

            var result = await _eventsRepository.DeleteEvent(eventId);
            if (!result)
            {
                _logger.LogError("Failed to delete event: {EventId}", eventId);
                TempData["ErrorMessage"] = "Failed to delete event. The event may not exist.";
                return RedirectToAction(nameof(Events));
            }

            _logger.LogInformation("Event {EventId} deleted successfully by admin", eventId);
            TempData["SuccessMessage"] = "Event deleted successfully.";
            return RedirectToAction(nameof(Events));
        }

        // GET: Admin/Likes
        public async Task<IActionResult> Likes()
        {
            var likes = await _likeRepository.GetAllLikesWithDetailsAsync();
            return View(likes);
        }

        // POST: Admin/DeleteLike
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLike(Guid likeId)
        {
            if (likeId == Guid.Empty)
            {
                _logger.LogWarning("Delete like attempt with empty GUID");
                TempData["ErrorMessage"] = "Valid Like ID is required.";
                return RedirectToAction(nameof(Likes));
            }

            var result = await _likeRepository.DeleteAsync(likeId);
            if (!result)
            {
                _logger.LogError("Failed to delete like: {LikeId}", likeId);
                TempData["ErrorMessage"] = "Failed to delete like.";
                return RedirectToAction(nameof(Likes));
            }

            _logger.LogInformation("Like {LikeId} deleted successfully by admin", likeId);
            TempData["SuccessMessage"] = "Like deleted successfully.";
            return RedirectToAction(nameof(Likes));
        }

        // GET: Admin/Dislikes
        public async Task<IActionResult> Dislikes()
        {
            var dislikes = await _dislikeRepository.GetAllDislikesWithDetailsAsync();
            return View(dislikes);
        }

        // POST: Admin/DeleteDislike
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDislike(Guid dislikeId)
        {
            if (dislikeId == Guid.Empty)
            {
                _logger.LogWarning("Delete dislike attempt with empty GUID");
                TempData["ErrorMessage"] = "Valid Dislike ID is required.";
                return RedirectToAction(nameof(Dislikes));
            }

            var result = await _dislikeRepository.DeleteAsync(dislikeId);
            if (!result)
            {
                _logger.LogError("Failed to delete dislike: {DislikeId}", dislikeId);
                TempData["ErrorMessage"] = "Failed to delete dislike.";
                return RedirectToAction(nameof(Dislikes));
            }

            _logger.LogInformation("Dislike {DislikeId} deleted successfully by admin", dislikeId);
            TempData["SuccessMessage"] = "Dislike deleted successfully.";
            return RedirectToAction(nameof(Dislikes));
        }

        // GET: Admin/FriendRequests
        public async Task<IActionResult> FriendRequests()
        {
            var friendRequests = await _friendsRepository.GetAllFriendRequestsAsync();
            return View(friendRequests);
        }

        // POST: Admin/UpdateFriendRequestStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFriendRequestStatus(Guid requestId, string status)
        {
            if (requestId == Guid.Empty)
            {
                _logger.LogWarning("Update friend request attempt with empty GUID");
                TempData["ErrorMessage"] = "Valid Friend Request ID is required.";
                return RedirectToAction(nameof(FriendRequests));
            }

            var request = await _friendsRepository.GetFriendRequestAsync(requestId);
            if (request == null)
            {
                _logger.LogWarning("Friend request not found for ID: {RequestId}", requestId);
                TempData["ErrorMessage"] = "Friend request not found.";
                return RedirectToAction(nameof(FriendRequests));
            }

            if (status == "accept")
            {
                request.Status = Models.Domain.Enums.FriendRequestStatus.Accepted;
                await _friendsRepository.UpdateAsync(request);
                TempData["SuccessMessage"] = "Friend request accepted.";
            }
            else if (status == "decline")
            {
                request.Status = Models.Domain.Enums.FriendRequestStatus.Declined;
                await _friendsRepository.UpdateAsync(request);
                TempData["SuccessMessage"] = "Friend request declined.";
            }
            else if (status == "delete")
            {
                await _friendsRepository.DeleteAsync(request);
                TempData["SuccessMessage"] = "Friend request deleted.";
            }

            return RedirectToAction(nameof(FriendRequests));
        }

        // GET: Admin/UserImages
        public async Task<IActionResult> UserImages()
        {
            var users = await _usersRepository.GetAllUsersAsync();
            var userImages = users
                .SelectMany(u => u.Images ?? new List<UserImage>())
                .Select(img => new UserImageViewModel
                {
                    ImageId = img.Id,
                    UserId = img.User?.Id ?? string.Empty,
                    UserName = $"{img.User?.FirstName ?? "Unknown"} {img.User?.LastName ?? "User"}",
                    ImagePath = img.ImagePath,
                })
                .ToList();

            return View(userImages);
        }

        // POST: Admin/DeleteUserImage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserImage(Guid imageId)
        {
            if (imageId == Guid.Empty)
            {
                _logger.LogWarning("Delete user image attempt with empty GUID");
                TempData["ErrorMessage"] = "Valid Image ID is required.";
                return RedirectToAction(nameof(UserImages));
            }

            // Find user with this image
            var users = await _usersRepository.GetAllUsersAsync();
            var userWithImage = users.FirstOrDefault(u =>
                u.Images != null && u.Images.Any(img => img.Id == imageId)
            );

            if (userWithImage == null)
            {
                _logger.LogWarning("Image not found for ID: {ImageId}", imageId);
                TempData["ErrorMessage"] = "Image not found.";
                return RedirectToAction(nameof(UserImages));
            }

            // Get the image
            var image = userWithImage.Images?.FirstOrDefault(img => img.Id == imageId);

            if (image == null)
            {
                _logger.LogWarning("Image not found for ID: {ImageId}", imageId);
                TempData["ErrorMessage"] = "Image not found.";
                return RedirectToAction(nameof(UserImages));
            }

            // Delete the image file from disk
            if (!string.IsNullOrEmpty(image.ImagePath))
            {
                var fullPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    image.ImagePath.TrimStart('/')
                );

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }

            // Remove image from user
            if (userWithImage.Images != null)
            {
                userWithImage.Images.Remove(image);

                // Update serial numbers
                int serialNumber = 0;
                foreach (var img in userWithImage.Images)
                {
                    img.SerialNumber = serialNumber++;
                }
            }

            // Update user in database
            var result = await _usersRepository.UpdateUserAsync(userWithImage);
            if (!result.Succeeded)
            {
                _logger.LogError("Failed to delete user image: {ImageId}", imageId);
                TempData["ErrorMessage"] = "Failed to delete user image.";
                return RedirectToAction(nameof(UserImages));
            }

            _logger.LogInformation("User image {ImageId} deleted successfully by admin", imageId);
            TempData["SuccessMessage"] = "User image deleted successfully.";
            return RedirectToAction(nameof(UserImages));
        }

        [HttpGet]
        public async Task<IActionResult> AbuseReports()
        {
            var reports = await _context.AbuseReports.ToListAsync();
            return View(reports);
        }
        // Видалення скарги
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAbuseReport(Guid reportId)
        {
            var report = await _context.AbuseReports.FindAsync(reportId);
            if (report != null)
            {
                _context.AbuseReports.Remove(report);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Report deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Report not found.";
            }
            return RedirectToAction("AbuseReports");
        }

        // Бан користувача
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BanUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                user.IsBanned = true; // Переконайся що в User є поле IsBanned (bool)
                await _userManager.UpdateAsync(user);
                TempData["SuccessMessage"] = "User banned successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "User not found.";
            }
            return RedirectToAction("AbuseReports");

        }

    }
}
