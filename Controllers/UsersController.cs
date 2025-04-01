using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniMate2.Models.Domain.Enums;
using UniMate2.Models.DTO;
using UniMate2.Repositories;

namespace UniMate2.Controllers
{
    public class UsersController(IUsersRepository usersRepository, IMapper mapper) : Controller
    {
        private readonly IUsersRepository _userRepository = usersRepository;
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
        public IActionResult Index()
        {
            var users = _userRepository.GetAllUsersAsync().Result;
            return View(users);
        }

        // Shows details of a user by email.
        public IActionResult DetailsByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("", "Email must be provided.");
                return View();
            }

            var user = _userRepository.GetUserByEmailAsync(email).Result;
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with email '{email}' not found.";
                return View("Error");
            }

            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Suggestions()
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
            var suggestedUsers = allUsers
                .Where(u => u.Id != currentUser.Id && u.Gender == currentUser.Gender)
                .ToList();

            var userDtos = _mapper.Map<List<UserDto>>(suggestedUsers);
            foreach (var user in allUsers)
            {
                Console.WriteLine($"User Email: {user.Email}, Gender: {user.Gender}");
            }
            return View("Suggestions", userDtos);
        }
        [Authorize]
        public async Task<IActionResult> ViewProfile(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("User ID is required.");
            }

            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
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
    }
}
