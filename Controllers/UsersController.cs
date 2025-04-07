using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;
using UniMate2.Models.DTO;
using UniMate2.Models.ViewModels;
using UniMate2.Repositories;

namespace UniMate2.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<UsersController> _logger;
        private readonly IFriendsRepository _friendsRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IDislikeRepository _dislikeRepository;

        public UsersController(
            IUsersRepository userRepository,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment,
            ILogger<UsersController> logger,
            IFriendsRepository friendsRepository,
            ILikeRepository likeRepository,
            IDislikeRepository dislikeRepository
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _friendsRepository = friendsRepository;
            _likeRepository = likeRepository;
            _dislikeRepository = dislikeRepository;
            _logger.LogInformation("UsersController initialized");
        }

        [Authorize]
        public IActionResult CurrentUser()
        {
            _logger.LogInformation("CurrentUser action called");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _logger.LogDebug("User ID: {UserId}", userId);

            var currentUser =
                userId != null ? _userRepository.GetUserByIdAsync(userId).Result : null;

            if (currentUser == null)
            {
                _logger.LogWarning("No current user found for ID: {UserId}", userId);
                ViewBag.ErrorMessage = "No current user found.";
                return View("Error");
            }

            _logger.LogInformation("Retrieved current user: {UserName}", currentUser.UserName);
            return View(currentUser);
        }

        // Lists all users.
        public IActionResult Index()
        {
            _logger.LogInformation("Index action called");
            var users = _userRepository.GetAllUsersAsync().Result;
            _logger.LogInformation("Retrieved {UserCount} users", users.Count);
            return View(users);
        }

        // Shows details of a user by email.
        public IActionResult DetailsByEmail(string email)
        {
            _logger.LogInformation("DetailsByEmail action called with email: {Email}", email);
            if (string.IsNullOrWhiteSpace(email))
            {
                _logger.LogWarning("Email not provided");
                ModelState.AddModelError("", "Email must be provided.");
                return View();
            }

            var user = _userRepository.GetUserByEmailAsync(email).Result;
            if (user == null)
            {
                _logger.LogWarning("User with email '{Email}' not found", email);
                ViewBag.ErrorMessage = $"User with email '{email}' not found.";
                return View("Error");
            }

            _logger.LogInformation("Retrieved user with email: {Email}", email);
            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Suggestions()
        {
            _logger.LogInformation("Suggestions action called");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("Authentication failure - no user ID found");
                return Challenge();
            }

            // Use the repository's GetUserSuggestionsAsync which already filters out disliked users
            var suggestedUsers = await _userRepository.GetUserSuggestionsAsync(userId, 20);

            _logger.LogInformation(
                "Generated {SuggestionCount} suggestions for user {UserId}",
                suggestedUsers.Count,
                userId
            );

            var userDtos = _mapper.Map<List<UserDto>>(suggestedUsers);
            return View("Suggestions", userDtos);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateCurrentUser(UpdateUserDto updateUserDto)
        {
            _logger.LogInformation("UpdateCurrentUser action called");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("Authentication failure - no user ID found");
                return Challenge();
            }

            var currentUser = await _userRepository.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                _logger.LogWarning("User not found in database: {UserId}", userId);
                return Challenge();
            }

            currentUser.University = updateUserDto.University ?? currentUser.University;
            currentUser.Faculty = updateUserDto.Faculty ?? currentUser.Faculty;

            // Fix type mismatches with proper null checking
            if (updateUserDto.Gender.HasValue)
                currentUser.Gender = updateUserDto.Gender.Value;

            if (updateUserDto.Orientation.HasValue)
                currentUser.Orientation = updateUserDto.Orientation.Value;

            currentUser.ZodiakSign = updateUserDto.ZodiakSign ?? currentUser.ZodiakSign;

            if (updateUserDto.IsSmoking.HasValue)
                currentUser.IsSmoking = updateUserDto.IsSmoking.Value;

            if (updateUserDto.IsDrinking.HasValue)
                currentUser.IsDrinking = updateUserDto.IsDrinking.Value;

            // Ensure proper handling of the PersonalityType
            currentUser.PersonalityType =
                !string.IsNullOrEmpty(updateUserDto.PersonalityType)
                && Enum.TryParse<PersonalityType>(
                    updateUserDto.PersonalityType,
                    out var personalityType
                )
                    ? personalityType
                    : currentUser.PersonalityType;

            if (updateUserDto.LookingFor.HasValue)
                currentUser.LookingFor = updateUserDto.LookingFor.Value;

            currentUser.Bio = updateUserDto.Bio ?? currentUser.Bio;

            // Add BirthDate handling - ensure UTC for PostgreSQL compatibility
            if (updateUserDto.BirthDate.HasValue)
            {
                // Convert to UTC - PostgreSQL requires DateTime.Kind = DateTimeKind.Utc
                DateTime utcBirthDate = DateTime.SpecifyKind(
                    updateUserDto.BirthDate.Value,
                    DateTimeKind.Utc
                );
                currentUser.BirthDate = utcBirthDate;
            }

            var result = await _userRepository.UpdateUserAsync(currentUser);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError("Error updating user: {ErrorDescription}", error.Description);
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Error");
            }

            _logger.LogInformation("User {UserName} updated successfully", currentUser.UserName);
            return RedirectToAction("CurrentUser");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdateCurrentUser()
        {
            _logger.LogInformation("UpdateCurrentUser GET action called");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("Authentication failure - no user ID found");
                return Challenge();
            }

            var currentUser = await _userRepository.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                _logger.LogWarning("User not found in database: {UserId}", userId);
                return Challenge();
            }

            var updateUserDto = _mapper.Map<UpdateUserDto>(currentUser);

            ViewBag.UserImages = currentUser.Images;

            _logger.LogInformation(
                "User {UserName} data prepared for update",
                currentUser.UserName
            );
            return View(updateUserDto);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadProfileImage(IFormFile profileImage)
        {
            _logger.LogInformation("UploadProfileImage action called");

            if (profileImage == null || profileImage.Length == 0)
            {
                _logger.LogWarning("No file selected for upload");
                ModelState.AddModelError(string.Empty, "Please select a file to upload");
                return RedirectToAction("UpdateCurrentUser");
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(profileImage.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                _logger.LogWarning("Invalid file type: {FileType}", extension);
                ModelState.AddModelError(
                    string.Empty,
                    "Invalid file type. Only JPG, PNG, and GIF are allowed."
                );
                return RedirectToAction("UpdateCurrentUser");
            }

            if (profileImage.Length > 5 * 1024 * 1024)
            {
                _logger.LogWarning("File size exceeds limit: {FileSize}", profileImage.Length);
                ModelState.AddModelError(string.Empty, "File size exceeds 5MB limit");
                return RedirectToAction("UpdateCurrentUser");
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("Authentication failure - no user ID found");
                return Challenge();
            }

            var currentUser = await _userRepository.GetUserAsync(User);
            if (currentUser == null)
            {
                _logger.LogWarning("User not found in database: {UserId}", userId);
                return Challenge();
            }

            try
            {
                _logger.LogDebug(
                    "Processing profile image upload for user: {UserName}",
                    currentUser.UserName
                );
                // First, let's write a test file to see if we have permissions
                var testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "test_write.txt");
                try
                {
                    System.IO.File.WriteAllText(testFilePath, "Test write access");
                    System.IO.File.Delete(testFilePath);
                    _logger.LogDebug("Test file write successful");
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Cannot write test file: {ErrorMessage}", ex.Message);
                }

                // Use absolute paths for everything
                var absoluteWebRootPath = _webHostEnvironment.WebRootPath;
                if (string.IsNullOrEmpty(absoluteWebRootPath))
                {
                    _logger.LogWarning("WebRootPath is empty, using fallback path");
                    absoluteWebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }

                // Ensure uploads directory exists with full permissions
                var uploadsDirectory = Path.Combine(absoluteWebRootPath, "uploads");
                if (!Directory.Exists(uploadsDirectory))
                {
                    _logger.LogDebug("Creating directory: {UploadsDirectory}", uploadsDirectory);
                    Directory.CreateDirectory(uploadsDirectory);
                }

                // Generate unique filename
                var uniqueFileName =
                    $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString().Substring(0, 8)}{extension}";
                var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

                _logger.LogDebug("Attempting to save file to: {FilePath}", filePath);

                // Instead of using Stream, read all bytes and write directly
                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await profileImage.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                // Write file directly to disk
                System.IO.File.WriteAllBytes(filePath, fileBytes);

                // Double-check if file exists after saving
                if (!System.IO.File.Exists(filePath))
                {
                    _logger.LogError("File does not exist after saving: {FilePath}", filePath);
                    ModelState.AddModelError(
                        string.Empty,
                        "Failed to save file to disk. Check server permissions."
                    );
                    return RedirectToAction("UpdateCurrentUser");
                }

                _logger.LogInformation(
                    "File successfully saved at: {FilePath}. Size: {FileSize} bytes",
                    filePath,
                    fileBytes.Length
                );

                currentUser.Images ??= [];

                var userImage = new UserImage
                {
                    User = currentUser,
                    ImagePath = $"/uploads/{uniqueFileName}",
                    SerialNumber = currentUser.Images.Count,
                };

                currentUser.Images.Add(userImage);

                var result = await _userRepository.UpdateUserAsync(currentUser);
                if (!result.Succeeded)
                {
                    System.IO.File.Delete(filePath);
                    foreach (var error in result.Errors)
                    {
                        _logger.LogError(
                            "Error updating user: {ErrorDescription}",
                            error.Description
                        );
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return RedirectToAction("UpdateCurrentUser");
                }

                _logger.LogInformation(
                    "Database updated successfully for user {UserName}",
                    currentUser.UserName
                );

                TempData["SuccessMessage"] =
                    $"Profile image uploaded successfully to {uniqueFileName}!";
                return RedirectToAction("UpdateCurrentUser");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error uploading profile image for user {UserId}: {ErrorMessage}",
                    userId,
                    ex.Message
                );

                // Pass the error directly to the view for debugging
                TempData["ErrorMessage"] =
                    $"Upload failed: {ex.Message}. Check console for details.";
                ModelState.AddModelError(string.Empty, $"Error uploading image: {ex.Message}");
                return RedirectToAction("UpdateCurrentUser");
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProfileImage(Guid imageId)
        {
            _logger.LogInformation(
                "DeleteProfileImage action called for image ID: {ImageId}",
                imageId
            );
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("Authentication failure - no user ID found");
                return Challenge();
            }

            var currentUser = await _userRepository.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                _logger.LogWarning("User not found in database: {UserId}", userId);
                return Challenge();
            }

            var imageToDelete = currentUser.Images?.FirstOrDefault(img => img.Id == imageId);
            if (imageToDelete == null)
            {
                _logger.LogWarning("Image not found for ID: {ImageId}", imageId);
                ModelState.AddModelError(string.Empty, "Image not found.");
                return RedirectToAction("UpdateCurrentUser");
            }

            try
            {
                var imagePath = imageToDelete.ImagePath;
                if (!string.IsNullOrEmpty(imagePath))
                {
                    var fullPath = Path.Combine(
                        _webHostEnvironment.WebRootPath,
                        imagePath.TrimStart('/')
                    );
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                        _logger.LogInformation(
                            "Deleted image file from disk: {FullPath}",
                            fullPath
                        );
                    }
                }

                currentUser.Images!.Remove(imageToDelete);

                int serialNumber = 0;
                foreach (var image in currentUser.Images)
                {
                    image.SerialNumber = serialNumber++;
                }

                var result = await _userRepository.UpdateUserAsync(currentUser);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogError(
                            "Error updating user: {ErrorDescription}",
                            error.Description
                        );
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return RedirectToAction("UpdateCurrentUser");
                }

                _logger.LogInformation(
                    "Image deleted successfully for user {UserName}",
                    currentUser.UserName
                );
                return RedirectToAction("UpdateCurrentUser");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error deleting image for user {UserId}: {ErrorMessage}",
                    userId,
                    ex.Message
                );
                ModelState.AddModelError(string.Empty, $"Error deleting image: {ex.Message}");
                return RedirectToAction("UpdateCurrentUser");
            }
        }

        // Shows details of a user by id with friend status
        [HttpGet]
        public async Task<IActionResult> ViewProfile(string id)
        {
            _logger.LogInformation("ViewProfile action called with id: {Id}", id);
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogWarning("User ID not provided");
                ModelState.AddModelError("", "User ID must be provided.");
                return RedirectToAction("Index", "Home");
            }

            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User with ID '{Id}' not found", id);
                return NotFound();
            }

            // If user is signed in, check if they are friends or have a pending request
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (currentUserId != null)
                {
                    // Check if viewing own profile
                    if (currentUserId == id)
                    {
                        return RedirectToAction("CurrentUser");
                    }

                    var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);

                    // Only proceed if we found the current user
                    if (currentUser != null)
                    {
                        // Check if they are friends or have pending friend requests
                        var friendRequests = await _friendsRepository.GetAllUserFriendRequestsAsync(
                            currentUser
                        );
                        var isFriend = friendRequests.Any(fr =>
                            (
                                (fr.Sender.Id == currentUserId && fr.Receiver.Id == id)
                                || (fr.Sender.Id == id && fr.Receiver.Id == currentUserId)
                            )
                            && fr.Status == FriendRequestStatus.Accepted
                        );

                        var isPendingFriend = friendRequests.Any(fr =>
                            (
                                (fr.Sender.Id == currentUserId && fr.Receiver.Id == id)
                                || (fr.Sender.Id == id && fr.Receiver.Id == currentUserId)
                            )
                            && fr.Status == FriendRequestStatus.Pending
                        );

                        ViewData["IsFriend"] = isFriend;
                        ViewData["IsPendingFriend"] = isPendingFriend;
                    }
                }
            }

            _logger.LogInformation("Retrieved user with ID: {Id}", id);
            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> LikeDislikeLog()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("Authentication failure - no user ID found");
                return Unauthorized();
            }

            _logger.LogInformation("LikeDislikeLog action called for user {UserId}", userId);

            var viewModel = new LikeDislikeLogViewModel();

            // Get users I liked
            var usersILiked = await _likeRepository.GetUserLikesWithDetailsAsync(userId);
            viewModel.UsersILiked = usersILiked
                .Select(l => new UserInteractionViewModel
                {
                    Id = l.LikedId,
                    Name = $"{l.Liked.FirstName} {l.Liked.LastName}",
                    ProfileImageUrl = GetProfileImageUrl(l.Liked),
                    Timestamp = l.LikedAt,
                })
                .ToList();

            // Get users who liked me
            var usersWhoLikedMe = await _likeRepository.GetLikesReceivedWithDetailsAsync(userId);
            viewModel.UsersWhoLikedMe = usersWhoLikedMe
                .Select(l => new UserInteractionViewModel
                {
                    Id = l.LikerId,
                    Name = $"{l.Liker.FirstName} {l.Liker.LastName}",
                    ProfileImageUrl = GetProfileImageUrl(l.Liker),
                    Timestamp = l.LikedAt,
                })
                .ToList();

            // Get users I disliked
            var usersIDisliked = await _dislikeRepository.GetUserDislikesWithDetailsAsync(userId);
            viewModel.UsersIDisliked = usersIDisliked
                .Select(d => new UserInteractionViewModel
                {
                    Id = d.DislikedUserId,
                    Name = $"{d.DislikedUser.FirstName} {d.DislikedUser.LastName}",
                    ProfileImageUrl = GetProfileImageUrl(d.DislikedUser),
                    Timestamp = d.CreatedAt,
                })
                .ToList();

            // Get users who disliked me
            var usersWhoDislikedMe = await _dislikeRepository.GetDislikesReceivedWithDetailsAsync(
                userId
            );
            viewModel.UsersWhoDislikedMe = usersWhoDislikedMe
                .Select(d => new UserInteractionViewModel
                {
                    Id = d.DislikingUserId,
                    Name = $"{d.DislikingUser.FirstName} {d.DislikingUser.LastName}",
                    ProfileImageUrl = GetProfileImageUrl(d.DislikingUser),
                    Timestamp = d.CreatedAt,
                })
                .ToList();

            return View(viewModel);
        }

        private string GetProfileImageUrl(User user)
        {
            if (user.Images != null && user.Images.Any())
            {
                return user.Images.OrderBy(i => i.SerialNumber).First().ImagePath;
            }
            return "/images/default-avatar.png"; // Default image path
        }
    }
}
