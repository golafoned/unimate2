using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniMate2.Models.Domain;
using UniMate2.Repositories;

namespace UniMate2.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private readonly IFriendRepository _friendRepository;
        private readonly UserManager<User> _userManager;
        private readonly IUsersRepository _usersRepository;

        public FriendController(IFriendRepository friendRepository, UserManager<User> userManager, IUsersRepository usersRepository)
        {
            _friendRepository = friendRepository;
            _userManager = userManager;
            _usersRepository = usersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest(string receiverId)
        {
            var sender = await _userManager.GetUserAsync(User);
            var receiver = await _usersRepository.GetUserByIdAsync(receiverId);

            if (sender == null || receiver == null || sender.Id == receiver.Id)
                return BadRequest();

            await _friendRepository.SendFriendRequest(sender, receiver);
            return RedirectToAction("ViewProfile", "Users", new { id = receiverId });
        }

        public async Task<IActionResult> FriendsList()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var friends = await _friendRepository.GetFriendsForUser(currentUser.Id);
            return View(friends);
        }
    }
}
