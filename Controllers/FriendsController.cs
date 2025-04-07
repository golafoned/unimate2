using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;
using UniMate2.Models.DTO;
using UniMate2.Models.ViewModels;
using UniMate2.Repositories;

namespace UniMate2.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IFriendsRepository _friendsRepository;

        public FriendsController(
            IUsersRepository usersRepository,
            IFriendsRepository friendsRepository
        )
        {
            _usersRepository = usersRepository;
            _friendsRepository = friendsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Suggestions(string searchTerm = null, int count = 10)
        {
            var currentUser = await _usersRepository.GetUserByEmailAsync(User.Identity!.Name!);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            List<User> suggestions;
            
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                suggestions = await _usersRepository.SearchUsersAsync(currentUser.Id, searchTerm, count);
            }
            else
            {
                suggestions = await _usersRepository.GetUserSuggestionsAsync(currentUser.Id, count);
            }

            var viewModel = new UserSuggestionsViewModel
            {
                Suggestions =
                [
                    .. suggestions.Select(u => new UserDto
                    {
                        Id = u.Id,
                        Email = u.Email ?? string.Empty,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        ProfilePicture = GetProfilePictureUrl(u),
                    }),
                ],
                SearchTerm = searchTerm
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest(FriendRequestRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _usersRepository.GetUserByEmailAsync(User.Identity!.Name!);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            var receiverUser = await _usersRepository.GetUserByEmailAsync(requestDto.ReceiverEmail);
            if (receiverUser == null)
            {
                return NotFound($"User with email '{requestDto.ReceiverEmail}' not found.");
            }

            // Check if a request already exists
            var requestExists = await _friendsRepository.IFFriendRequestExistsAsync(
                currentUser.Email!,
                receiverUser.Email!
            );
            if (requestExists)
            {
                return BadRequest("A friend request already exists between these users.");
            }

            var friendRequest = new FriendRequest
            {
                Id = Guid.NewGuid(),
                Sender = currentUser,
                Receiver = receiverUser,
                // Use DateTime.Now instead of DateTime.UtcNow to match PostgreSQL's timestamp without time zone
                RequestDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                Status = FriendRequestStatus.Pending,
            };

            await _friendsRepository.AddAsync(friendRequest);
            return RedirectToAction("Suggestions");
        }

        [HttpGet]
        public async Task<IActionResult> Requests()
        {
            var currentUser = await _usersRepository.GetUserByEmailAsync(User.Identity!.Name!);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            var requests = await _friendsRepository.GetAllUserFriendRequestsAsync(currentUser);

            var viewModel = new FriendRequestsViewModel
            {
                ReceivedRequests = requests
                    .Where(r =>
                        r.Receiver.Id == currentUser.Id && r.Status == FriendRequestStatus.Pending
                    )
                    .Select(r => new FriendRequestDto
                    {
                        Id = r.Id,
                        Sender = new UserDto
                        {
                            Id = r.Sender.Id,
                            Email = r.Sender.Email ?? string.Empty,
                            FirstName = r.Sender.FirstName,
                            LastName = r.Sender.LastName,
                            ProfilePicture = GetProfilePictureUrl(r.Sender),
                        },
                        Receiver = new UserDto
                        {
                            Id = r.Receiver.Id,
                            Email = r.Receiver.Email ?? string.Empty,
                            FirstName = r.Receiver.FirstName,
                            LastName = r.Receiver.LastName,
                            ProfilePicture = GetProfilePictureUrl(r.Receiver),
                        },
                        Status = r.Status.ToString(),
                    })
                    .ToList(),

                SentRequests = requests
                    .Where(r =>
                        r.Sender.Id == currentUser.Id && r.Status == FriendRequestStatus.Pending
                    )
                    .Select(r => new FriendRequestDto
                    {
                        Id = r.Id,
                        Sender = new UserDto
                        {
                            Id = r.Sender.Id,
                            Email = r.Sender.Email ?? string.Empty,
                            FirstName = r.Sender.FirstName,
                            LastName = r.Sender.LastName,
                            ProfilePicture = GetProfilePictureUrl(r.Sender),
                        },
                        Receiver = new UserDto
                        {
                            Id = r.Receiver.Id,
                            Email = r.Receiver.Email ?? string.Empty,
                            FirstName = r.Receiver.FirstName,
                            LastName = r.Receiver.LastName,
                            ProfilePicture = GetProfilePictureUrl(r.Receiver),
                        },
                        Status = r.Status.ToString(),
                    })
                    .ToList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRequestStatus(Guid requestId, string action)
        {
            var currentUser = await _usersRepository.GetUserByEmailAsync(User.Identity!.Name!);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            var request = await _friendsRepository.GetFriendRequestAsync(requestId);
            if (request == null)
            {
                return NotFound("Friend request not found.");
            }

            if (action.ToLower() == "cancel")
            {
                // For cancel action, ensure the current user is the sender
                if (request.Sender.Id != currentUser.Id)
                {
                    return Forbid("You cannot cancel this request.");
                }

                // You can either delete the request entirely
                await _friendsRepository.DeleteAsync(request);
            }
            else
            {
                // Ensure the current user is the receiver of the request for accept/decline actions
                if (request.Receiver.Id != currentUser.Id)
                {
                    return Forbid("You cannot update this request.");
                }

                if (action.ToLower() == "accept")
                {
                    request.Status = FriendRequestStatus.Accepted;
                    await _friendsRepository.UpdateAsync(request);
                }
                else if (action.ToLower() == "decline")
                {
                    request.Status = FriendRequestStatus.Declined;
                    await _friendsRepository.UpdateAsync(request);
                }
            }

            return RedirectToAction("Requests");
        }

        // Helper method to get profile picture URL from a user
        private string? GetProfilePictureUrl(User user)
        {
            // Get the first image from the user's images collection, or return null
            return user.Images?.FirstOrDefault()?.ImagePath;
        }
    }
}
