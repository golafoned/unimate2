using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Moq;
using UniMate2.Controllers;
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;
using UniMate2.Models.ViewModels.Admin;
using UniMate2.Repositories;
using UniMate2.Tests.Helpers;
using Xunit;

namespace UniMate2.Tests.Controllers
{
    public class AdminControllerTests
    {
        private readonly Mock<IUsersRepository> _mockUsersRepository;
        private readonly Mock<IEventsRepository> _mockEventsRepository;
        private readonly Mock<ILogger<AdminController>> _mockLogger;
        private readonly Mock<ILikeRepository> _mockLikeRepository;
        private readonly Mock<IDislikeRepository> _mockDislikeRepository;
        private readonly Mock<IFriendsRepository> _mockFriendsRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        private readonly Mock<RoleManager<IdentityRole>> _mockRoleManager;
        private readonly AdminController _controller;

        public AdminControllerTests()
        {
            _mockUsersRepository = new Mock<IUsersRepository>();
            _mockEventsRepository = new Mock<IEventsRepository>();
            _mockLogger = new Mock<ILogger<AdminController>>();
            _mockLikeRepository = new Mock<ILikeRepository>();
            _mockDislikeRepository = new Mock<IDislikeRepository>();
            _mockFriendsRepository = new Mock<IFriendsRepository>();
            _mockUserManager = UserManagerMock.CreateMock();
            _mockRoleManager = new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(),
                null,
                null,
                null,
                null
            );

            _controller = new AdminController(
                _mockUsersRepository.Object,
                _mockEventsRepository.Object,
                _mockLogger.Object,
                _mockLikeRepository.Object,
                _mockDislikeRepository.Object,
                _mockFriendsRepository.Object,
                _mockUserManager.Object,
                _mockRoleManager.Object
            );

            // Initialize TempData for the controller to prevent NullReferenceException
            _controller.TempData = new TempDataDictionary(
                new DefaultHttpContext(),
                Mock.Of<ITempDataProvider>()
            );
        }

        [Fact]
        public async Task Dashboard_ReturnsViewWithDashboardViewModel()
        {
            // Arrange
            var users = new List<User> { new User(), new User() };
            var queryableUsers = users.AsQueryable();

            var events = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 1",
                    Description = "Description 1",
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2),
                    Location = "Location 1",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 2",
                    Description = "Description 2",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(4),
                    Location = "Location 2",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 3",
                    Description = "Description 3",
                    StartDate = DateTime.Now.AddDays(5),
                    EndDate = DateTime.Now.AddDays(6),
                    Location = "Location 3",
                },
            };

            _mockUserManager.Setup(x => x.Users).Returns(queryableUsers);
            _mockEventsRepository.Setup(x => x.GetAllEvents()).ReturnsAsync(events);
            _mockLikeRepository.Setup(x => x.GetTotalLikesCountAsync()).ReturnsAsync(10);
            _mockDislikeRepository.Setup(x => x.GetTotalDislikesCountAsync()).ReturnsAsync(5);
            _mockFriendsRepository.Setup(x => x.GetTotalFriendRequestsCountAsync()).ReturnsAsync(7);

            // Act
            var result = await _controller.Dashboard();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<AdminDashboardViewModel>(viewResult.Model);
            Assert.Equal(2, model.TotalUsers);
            Assert.Equal(3, model.TotalEvents);
            Assert.Equal(10, model.TotalLikes);
            Assert.Equal(5, model.TotalDislikes);
            Assert.Equal(7, model.TotalFriendRequests);
        }

        [Fact]
        public async Task Users_ReturnsViewWithUsersList()
        {
            // Arrange
            var users = new List<User> { new User(), new User() };
            _mockUsersRepository.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.Users();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<User>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task EditUser_WithValidId_ReturnsViewWithUser()
        {
            // Arrange
            var userId = "user123";
            var user = new User { Id = userId, Email = "user@example.com" };
            var roles = new List<string> { "User" };
            var allRoles = new List<IdentityRole>
            {
                new IdentityRole("User"),
                new IdentityRole("Admin"),
            };

            _mockUsersRepository.Setup(x => x.GetUserByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(roles);
            _mockRoleManager.Setup(x => x.Roles).Returns(allRoles.AsQueryable());

            // Act
            var result = await _controller.EditUser(userId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<EditUserViewModel>(viewResult.Model);
            Assert.Equal(userId, model.User.Id);
            Assert.Single(model.UserRoles);
            Assert.Equal(2, model.AllRoles.Count);
        }

        [Fact]
        public async Task EditUser_WithInvalidId_RedirectsToUsers()
        {
            // Arrange
            string userId = string.Empty; // Using empty string instead of null

            // Act
            var result = await _controller.EditUser(userId);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Users", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["ErrorMessage"]);
        }

        [Fact]
        public async Task UpdateUser_WithValidData_RedirectsToUsers()
        {
            // Arrange
            var userId = "user123";
            var user = new User { Id = userId, Email = "user@example.com" };
            var updatedUser = new User
            {
                Email = "updated@example.com",
                FirstName = "Updated",
                LastName = "User",
            };
            var selectedRoles = new List<string> { "Admin" };
            var currentRoles = new List<string> { "User" };

            _mockUsersRepository.Setup(x => x.GetUserByIdAsync(userId)).ReturnsAsync(user);
            _mockUsersRepository
                .Setup(x => x.UpdateUserAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(currentRoles);
            _mockUserManager
                .Setup(x => x.RemoveFromRoleAsync(user, It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager
                .Setup(x => x.AddToRoleAsync(user, It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.UpdateUser(userId, updatedUser, selectedRoles);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Users", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);

            // Verify user properties were updated
            Assert.Equal(updatedUser.Email, user.Email);
            Assert.Equal(updatedUser.FirstName, user.FirstName);

            // Verify role management methods were called
            _mockUserManager.Verify(x => x.RemoveFromRoleAsync(user, "User"), Times.Once);
            _mockUserManager.Verify(x => x.AddToRoleAsync(user, "Admin"), Times.Once);
        }

        [Fact]
        public async Task DeleteUser_WithValidId_RedirectsToUsers()
        {
            // Arrange
            var userId = "user123";

            _mockUsersRepository
                .Setup(x => x.DeleteUserAsync(userId))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.DeleteUser(userId);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Users", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);
            _mockUsersRepository.Verify(x => x.DeleteUserAsync(userId), Times.Once);
        }

        [Fact]
        public async Task Events_ReturnsViewWithEventsList()
        {
            // Arrange
            var events = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 1",
                    Description = "Description 1",
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2),
                    Location = "Location 1",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 2",
                    Description = "Description 2",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(4),
                    Location = "Location 2",
                },
            };
            _mockEventsRepository.Setup(x => x.GetAllEvents()).ReturnsAsync(events);

            // Act
            var result = await _controller.Events();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Event>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task EditEvent_WithValidId_ReturnsViewWithEvent()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            var eventEntity = new Event
            {
                Id = eventId,
                Title = "Test Event",
                Description = "Test Event Description",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Location = "Test Location",
            };

            _mockEventsRepository.Setup(x => x.GetEventById(eventId)).ReturnsAsync(eventEntity);

            // Act
            var result = await _controller.EditEvent(eventId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Event>(viewResult.Model);
            Assert.Equal(eventId, model.Id);
        }

        [Fact]
        public async Task UpdateEvent_WithValidData_RedirectsToEvents()
        {
            // Arrange
            var eventEntity = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Updated Event",
                Description = "Updated Description",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Location = "Updated Location",
            };

            _mockEventsRepository.Setup(x => x.UpdateEvent(It.IsAny<Event>())).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateEvent(eventEntity);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Events", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);
            _mockEventsRepository.Verify(x => x.UpdateEvent(eventEntity), Times.Once);
        }

        [Fact]
        public async Task DeleteEvent_WithValidId_RedirectsToEvents()
        {
            // Arrange
            var eventId = Guid.NewGuid();

            _mockEventsRepository.Setup(x => x.DeleteEvent(eventId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteEvent(eventId);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Events", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);
            _mockEventsRepository.Verify(x => x.DeleteEvent(eventId), Times.Once);
        }

        [Fact]
        public async Task Likes_ReturnsViewWithLikesList()
        {
            // Arrange
            var likes = new List<Like> { new Like(), new Like() };
            _mockLikeRepository.Setup(x => x.GetAllLikesWithDetailsAsync()).ReturnsAsync(likes);

            // Act
            var result = await _controller.Likes();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Like>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task DeleteLike_WithValidId_RedirectsToLikes()
        {
            // Arrange
            var likeId = Guid.NewGuid();

            _mockLikeRepository.Setup(x => x.DeleteAsync(likeId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteLike(likeId);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Likes", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);
            _mockLikeRepository.Verify(x => x.DeleteAsync(likeId), Times.Once);
        }

        [Fact]
        public async Task Dislikes_ReturnsViewWithDislikesList()
        {
            // Arrange
            var dislikes = new List<UserDislike> { new UserDislike(), new UserDislike() };
            _mockDislikeRepository
                .Setup(x => x.GetAllDislikesWithDetailsAsync())
                .ReturnsAsync(dislikes);

            // Act
            var result = await _controller.Dislikes();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<UserDislike>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task DeleteDislike_WithValidId_RedirectsToDisikes()
        {
            // Arrange
            var dislikeId = Guid.NewGuid();

            _mockDislikeRepository.Setup(x => x.DeleteAsync(dislikeId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteDislike(dislikeId);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Dislikes", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);
            _mockDislikeRepository.Verify(x => x.DeleteAsync(dislikeId), Times.Once);
        }

        [Fact]
        public async Task FriendRequests_ReturnsViewWithFriendRequestsList()
        {
            // Arrange
            var sender1 = new User { Id = "sender1", Email = "sender1@example.com" };
            var receiver1 = new User { Id = "receiver1", Email = "receiver1@example.com" };
            var sender2 = new User { Id = "sender2", Email = "sender2@example.com" };
            var receiver2 = new User { Id = "receiver2", Email = "receiver2@example.com" };

            var friendRequests = new List<FriendRequest>
            {
                new FriendRequest
                {
                    Id = Guid.NewGuid(),
                    Sender = sender1,
                    Receiver = receiver1,
                    Status = FriendRequestStatus.Pending,
                },
                new FriendRequest
                {
                    Id = Guid.NewGuid(),
                    Sender = sender2,
                    Receiver = receiver2,
                    Status = FriendRequestStatus.Pending,
                },
            };
            _mockFriendsRepository
                .Setup(x => x.GetAllFriendRequestsAsync())
                .ReturnsAsync(friendRequests);

            // Act
            var result = await _controller.FriendRequests();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<FriendRequest>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task UpdateFriendRequestStatus_Accept_UpdatesStatusAndRedirects()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var sender = new User { Id = "sender", Email = "sender@example.com" };
            var receiver = new User { Id = "receiver", Email = "receiver@example.com" };
            var request = new FriendRequest
            {
                Id = requestId,
                Status = FriendRequestStatus.Pending,
                Sender = sender,
                Receiver = receiver,
            };

            _mockFriendsRepository
                .Setup(x => x.GetFriendRequestAsync(requestId))
                .ReturnsAsync(request);

            // Act
            var result = await _controller.UpdateFriendRequestStatus(requestId, "accept");

            // Assert
            Assert.Equal(FriendRequestStatus.Accepted, request.Status);
            _mockFriendsRepository.Verify(x => x.UpdateAsync(request), Times.Once);

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("FriendRequests", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);
        }

        [Fact]
        public async Task UpdateFriendRequestStatus_Delete_DeletesRequestAndRedirects()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var sender = new User { Id = "sender", Email = "sender@example.com" };
            var receiver = new User { Id = "receiver", Email = "receiver@example.com" };
            var request = new FriendRequest
            {
                Id = requestId,
                Sender = sender,
                Receiver = receiver,
                Status = FriendRequestStatus.Pending,
            };

            _mockFriendsRepository
                .Setup(x => x.GetFriendRequestAsync(requestId))
                .ReturnsAsync(request);

            // Act
            var result = await _controller.UpdateFriendRequestStatus(requestId, "delete");

            // Assert
            _mockFriendsRepository.Verify(x => x.DeleteAsync(request), Times.Once);

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("FriendRequests", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);
        }

        [Fact]
        public async Task UserImages_ReturnsViewWithUserImagesList()
        {
            // Arrange
            var user1 = new User
            {
                Id = "user1",
                FirstName = "John",
                LastName = "Doe",
                Images = new List<UserImage>
                {
                    new UserImage
                    {
                        Id = Guid.NewGuid(),
                        ImagePath = "/images/user1.jpg",
                        // Initialize User property to prevent NullReferenceException
                        User = new User
                        {
                            Id = "user1",
                            FirstName = "John",
                            LastName = "Doe",
                        },
                    },
                },
            };

            var user2 = new User
            {
                Id = "user2",
                FirstName = "Jane",
                LastName = "Smith",
                Images = new List<UserImage>
                {
                    new UserImage
                    {
                        Id = Guid.NewGuid(),
                        ImagePath = "/images/user2.jpg",
                        // Initialize User property to prevent NullReferenceException
                        User = new User
                        {
                            Id = "user2",
                            FirstName = "Jane",
                            LastName = "Smith",
                        },
                    },
                    new UserImage
                    {
                        Id = Guid.NewGuid(),
                        ImagePath = "/images/user2b.jpg",
                        // Initialize User property to prevent NullReferenceException
                        User = new User
                        {
                            Id = "user2",
                            FirstName = "Jane",
                            LastName = "Smith",
                        },
                    },
                },
            };

            var users = new List<User> { user1, user2 };
            _mockUsersRepository.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.UserImages();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<UserImageViewModel>>(viewResult.Model);
            Assert.Equal(3, model.Count); // 1 from user1, 2 from user2
        }

        [Fact]
        public async Task DeleteUserImage_WithValidId_RemovesImageAndRedirects()
        {
            // Arrange
            var imageId = Guid.NewGuid();
            var imagePath = "/images/user1.jpg";
            var user = new User
            {
                Id = "user1",
                Images = new List<UserImage>
                {
                    new UserImage
                    {
                        Id = imageId,
                        ImagePath = imagePath,
                        SerialNumber = 0,
                        // Initialize User property to prevent NullReferenceException
                        User = new User
                        {
                            Id = "user1",
                            FirstName = "John",
                            LastName = "Doe",
                        },
                    },
                    new UserImage
                    {
                        Id = Guid.NewGuid(),
                        ImagePath = "/images/user1b.jpg",
                        SerialNumber = 1,
                        // Initialize User property to prevent NullReferenceException
                        User = new User
                        {
                            Id = "user1",
                            FirstName = "John",
                            LastName = "Doe",
                        },
                    },
                },
            };

            var users = new List<User> { user };
            _mockUsersRepository.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(users);
            _mockUsersRepository
                .Setup(x => x.UpdateUserAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            // Mock System.IO.File to avoid actual file operations
            // In a real test, you might use a file system abstraction or a more complex setup

            // Act
            var result = await _controller.DeleteUserImage(imageId);

            // Assert
            Assert.Single(user.Images); // One image should be removed
            Assert.Equal(0, user.Images[0].SerialNumber); // Remaining image should have serial number reset to 0
            _mockUsersRepository.Verify(x => x.UpdateUserAsync(user), Times.Once);

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("UserImages", redirectResult.ActionName);
            Assert.NotNull(_controller.TempData["SuccessMessage"]);
        }
    }
}
