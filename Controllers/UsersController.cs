using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;
using UniMate2.Models.DTO;
using UniMate2.Repositories;

namespace UniMate2.Controllers
{
    public class UsersController(IUsersRepository usersRepository, IFriendRequestRepository friendRequestRepository, IMapper mapper) : Controller
    {
        private readonly IUsersRepository _userRepository = usersRepository;
        private readonly IFriendRequestRepository _friendRequestRepository = friendRequestRepository;
        private readonly IMapper _mapper = mapper;

        [Authorize]
        public IActionResult CurrentUser()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var currentUser =
                userId != null ? _userRepository.GetUserByIdAsync(userId).Result : null;

            if (currentUser == null)
            {
                ViewBag.ErrorMessage = "No current user found.";
                return View("Error");
            }

            return View(currentUser);
        }

        // Lists all users.
        public async Task<IActionResult> Index(string email)
        {
            var users = await _userRepository.GetAllUsersAsync();
            
            // Apply email filter if provided
            if (!string.IsNullOrEmpty(email))
            {
                users = users
                    .Where(u => u.Email != null && u.Email.Contains(email, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                    
                // Store the search term for displaying in the view
                ViewData["CurrentSearch"] = email;
            }
            
            return View(users);
        }

        // Shows details of a user by email.
        public async Task<IActionResult> DetailsByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("", "Email must be provided.");
                return View();
            }

            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with email '{email}' not found.";
                return View("Error");
            }

            // Get current user ID from claims (if user is logged in)
            var currentUserId = User.Identity.IsAuthenticated ? 
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value : null;

            // Check if a friend request exists between current user and profile user
            if (currentUserId != null && currentUserId != user.Id)
            {
                var friendRequestExists = await _friendRequestRepository.DoesFriendRequestExistAsync(currentUserId, user.Id);
                ViewData["FriendRequestExists"] = friendRequestExists;
                
                // Get list of friends for the profile
                var friendships = await _friendRequestRepository.GetFriendsForUserAsync(user.Id);
                
                // Format the friendship data for the view
                var friends = friendships.Select(fr => 
                {
                    if (fr.RequesterId == user.Id)
                        return fr.Recipient;
                    else
                        return fr.Requester;
                }).ToList();
                
                ViewData["Friends"] = friends;
            }

            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Suggestions(string email)
        {
            // Get current user ID from claims.
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            var currentUser = await _userRepository.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                return Challenge();
            }

            var allUsers = await _userRepository.GetAllUsersAsync();
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    allUsers[i].Gender = Gender.Female;
                }
            }
            
            var suggestedUsers = new List<UniMate2.Models.Domain.User>();
            
            // If searching by email, prioritize email search over gender matching
            if (!string.IsNullOrEmpty(email))
            {
                suggestedUsers = allUsers
                    .Where(u => u.Id != currentUser.Id && u.Email != null && 
                          u.Email.Contains(email, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                    
                // Store the search term for displaying in the view
                ViewData["CurrentSearch"] = email;
            }
            else
            {
                // Default behavior: show gender-based suggestions
                suggestedUsers = allUsers
                    .Where(u => u.Id != currentUser.Id && u.Gender == currentUser.Gender)
                    .ToList();
            }

            var userDtos = _mapper.Map<List<UserDto>>(suggestedUsers);
            foreach (var user in allUsers)
            {
                Console.WriteLine($"User Email: {user.Email}, Gender: {user.Gender}");
            }
            return View("Suggestions", userDtos);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateCurrentUser(UpdateUserDto updateUserDto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            var currentUser = await _userRepository.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                return Challenge();
            }

            // Map the updated fields from the DTO to the current user.
            currentUser.University = updateUserDto.University ?? currentUser.University;
            currentUser.Faculty = updateUserDto.Faculty ?? currentUser.Faculty;
            currentUser.Gender = updateUserDto.Gender ?? currentUser.Gender;
            currentUser.Orientation = updateUserDto.Orientation ?? currentUser.Orientation;
            currentUser.ZodiakSign = updateUserDto.ZodiakSign ?? currentUser.ZodiakSign;
            currentUser.IsSmoking = updateUserDto.IsSmoking ?? currentUser.IsSmoking;
            currentUser.IsDrinking = updateUserDto.IsDrinking ?? currentUser.IsDrinking;
            currentUser.PersonalityType =
                updateUserDto.PersonalityType ?? currentUser.PersonalityType;
            currentUser.LookingFor = updateUserDto.LookingFor ?? currentUser.LookingFor;
            currentUser.Bio = updateUserDto.Bio ?? currentUser.Bio;

            var result = await _userRepository.UpdateUserAsync(currentUser);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Error");
            }

            return RedirectToAction("CurrentUser");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdateCurrentUser()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            var currentUser = await _userRepository.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                return Challenge();
            }

            var updateUserDto = _mapper.Map<UpdateUserDto>(currentUser);
            return View(updateUserDto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendFriendRequest(string recipientId)
        {
            if (string.IsNullOrEmpty(recipientId))
            {
                return BadRequest("Recipient ID is required.");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            // Check if users are the same
            if (userId == recipientId)
            {
                return BadRequest("You cannot send a friend request to yourself.");
            }

            // Check friendship status
            var status = await _friendRequestRepository.GetFriendshipStatusAsync(userId, recipientId);
            
            if (status != Models.Domain.Enums.FriendshipStatus.None)
            {
                string message = status switch
                {
                    Models.Domain.Enums.FriendshipStatus.Friends => "You are already friends with this user.",
                    Models.Domain.Enums.FriendshipStatus.RequestSent => "You have already sent a friend request to this user.",
                    Models.Domain.Enums.FriendshipStatus.RequestReceived => "This user has already sent you a friend request. Check your friend requests.",
                    _ => "Cannot send friend request."
                };
                
                TempData["FriendRequestError"] = message;
                var recipient = await _userRepository.GetUserByIdAsync(recipientId);
                return RedirectToAction("DetailsByEmail", new { email = recipient.Email });
            }

            try
            {
                // Create friend request
                var request = await _friendRequestRepository.CreateFriendRequestAsync(userId, recipientId);
                Console.WriteLine($"Created friend request: {request.Id} from {userId} to {recipientId}");
                
                TempData["FriendRequestMessage"] = "Friend request sent successfully!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating friend request: {ex.Message}");
                TempData["FriendRequestError"] = "An error occurred while sending the friend request.";
            }
            
            // Get the recipient's email to redirect back to their profile
            var recipientUser = await _userRepository.GetUserByIdAsync(recipientId);
            return RedirectToAction("DetailsByEmail", new { email = recipientUser.Email });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AcceptFriendRequest(Guid requestId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            // Get the request and check if it's already accepted
            var request = await _friendRequestRepository.GetFriendRequestByIdAsync(requestId);

            if (request == null)
            {
                TempData["FriendRequestError"] = "Friend request not found.";
                return RedirectToAction("FriendRequests");
            }

            // Make sure this user is the recipient
            if (request.RecipientId != userId)
            {
                TempData["FriendRequestError"] = "You can only accept friend requests sent to you.";
                return RedirectToAction("FriendRequests");
            }

            // Check if it's already accepted
            if (request.IsAccepted)
            {
                TempData["FriendRequestError"] = "This friend request was already accepted.";
                return RedirectToAction("FriendRequests");
            }

            var result = await _friendRequestRepository.AcceptFriendRequestAsync(requestId);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    TempData["FriendRequestError"] = error.Description;
                }
                return RedirectToAction("FriendRequests");
            }

            TempData["FriendRequestMessage"] = "Friend request accepted successfully!";
            return RedirectToAction("FriendRequests");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RejectFriendRequest(Guid requestId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            var result = await _friendRequestRepository.DeleteFriendRequestAsync(requestId);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return RedirectToAction("FriendRequests");
            }

            return RedirectToAction("FriendRequests");
        }

        [Authorize]
        public async Task<IActionResult> FriendRequests()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            Console.WriteLine($"Getting friend requests for user: {userId}");
            var pendingRequests = await _friendRequestRepository.GetPendingRequestsForUserAsync(userId);
            Console.WriteLine($"Found {pendingRequests.Count} pending requests");

            return View(pendingRequests);
        }

        [Authorize]
        public async Task<IActionResult> Friends()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            var friendships = await _friendRequestRepository.GetFriendsForUserAsync(userId);
            
            // Format the friendship data for the view
            var friends = friendships.Select(fr => 
            {
                if (fr.RequesterId == userId)
                    return fr.Recipient;
                else
                    return fr.Requester;
            }).ToList();
            
            return View(friends);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFriend(string friendId)
        {
            if (string.IsNullOrEmpty(friendId))
            {
                return BadRequest("Friend ID is required.");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Challenge();
            }

            var result = await _friendRequestRepository.RemoveFriendshipAsync(userId, friendId);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    TempData["FriendErrorMessage"] = error.Description;
                }
            }
            else
            {
                TempData["FriendSuccessMessage"] = "Friend removed successfully.";
            }

            return RedirectToAction("Friends");
        }
    }
}
