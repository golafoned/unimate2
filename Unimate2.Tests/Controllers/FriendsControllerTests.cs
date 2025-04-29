using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UniMate2.Controllers;
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;
using UniMate2.Models.DTO;
using UniMate2.Models.ViewModels;
using UniMate2.Repositories;
using Xunit;

namespace Unimate2.Tests.Controllers
{
    public class FriendsControllerTests
    {
        private readonly Mock<IUsersRepository> _mockUsersRepository;
        private readonly Mock<IFriendsRepository> _mockFriendsRepository;
        private readonly FriendsController _controller;
        private readonly string _userEmail = "test@example.com";

        public FriendsControllerTests()
        {
            _mockUsersRepository = new Mock<IUsersRepository>();
            _mockFriendsRepository = new Mock<IFriendsRepository>();
            _controller = new FriendsController(
                _mockUsersRepository.Object,
                _mockFriendsRepository.Object
            );

            // Setup controller context with user identity
            var identity = new GenericIdentity(_userEmail);
            var principal = new ClaimsPrincipal(identity);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = principal },
            };
        }

        #region Suggestions Tests

        [Fact]
        public async Task Suggestions_WhenUserNotFound_ReturnsUnauthorized()
        {
            // Arrange
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync((User)null!);

            // Act
            var result = await _controller.Suggestions();

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task Suggestions_WithoutSearchTerm_ReturnsSuggestions()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var suggestions = new List<User>
            {
                new User
                {
                    Id = "user2",
                    Email = "user2@example.com",
                    FirstName = "User",
                    LastName = "Two",
                },
                new User
                {
                    Id = "user3",
                    Email = "user3@example.com",
                    FirstName = "User",
                    LastName = "Three",
                },
            };

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockUsersRepository
                .Setup(repo => repo.GetUserSuggestionsAsync(currentUser.Id, 10))
                .ReturnsAsync(suggestions);

            // Act
            var result = await _controller.Suggestions();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<UserSuggestionsViewModel>(viewResult.Model);
            Assert.Equal(2, viewModel.Suggestions.Count);
            Assert.Equal("", viewModel.SearchTerm);
        }

        [Fact]
        public async Task Suggestions_WithSearchTerm_ReturnsFilteredSuggestions()
        {
            // Arrange
            var searchTerm = "search";
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var suggestions = new List<User>
            {
                new User
                {
                    Id = "user2",
                    Email = "user2@example.com",
                    FirstName = "User",
                    LastName = "Search",
                },
            };

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockUsersRepository
                .Setup(repo => repo.SearchUsersAsync(currentUser.Id, searchTerm, 10))
                .ReturnsAsync(suggestions);

            // Act
            var result = await _controller.Suggestions(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<UserSuggestionsViewModel>(viewResult.Model);
            Assert.Single(viewModel.Suggestions);
            Assert.Equal(searchTerm, viewModel.SearchTerm);
        }

        #endregion

        #region SendRequest Tests

        [Fact]
        public async Task SendRequest_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("ReceiverEmail", "Required");
            var requestDto = new FriendRequestRequestDto { ReceiverEmail = "" };

            // Act
            var result = await _controller.SendRequest(requestDto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task SendRequest_CurrentUserNotFound_ReturnsUnauthorized()
        {
            // Arrange
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync((User)null!);
            var requestDto = new FriendRequestRequestDto { ReceiverEmail = "receiver@example.com" };

            // Act
            var result = await _controller.SendRequest(requestDto);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task SendRequest_ReceiverUserNotFound_ReturnsNotFound()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync("receiver@example.com"))
                .ReturnsAsync((User)null!);
            var requestDto = new FriendRequestRequestDto { ReceiverEmail = "receiver@example.com" };

            // Act
            var result = await _controller.SendRequest(requestDto);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task SendRequest_RequestAlreadyExists_ReturnsBadRequest()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var receiverUser = new User { Id = "user2", Email = "receiver@example.com" };
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync("receiver@example.com"))
                .ReturnsAsync(receiverUser);
            _mockFriendsRepository
                .Setup(repo =>
                    repo.IFFriendRequestExistsAsync(currentUser.Email!, receiverUser.Email!)
                )
                .ReturnsAsync(true);
            var requestDto = new FriendRequestRequestDto { ReceiverEmail = "receiver@example.com" };

            // Act
            var result = await _controller.SendRequest(requestDto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task SendRequest_Success_RedirectsToSuggestions()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var receiverUser = new User { Id = "user2", Email = "receiver@example.com" };
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync("receiver@example.com"))
                .ReturnsAsync(receiverUser);
            _mockFriendsRepository
                .Setup(repo =>
                    repo.IFFriendRequestExistsAsync(currentUser.Email!, receiverUser.Email!)
                )
                .ReturnsAsync(false);
            _mockFriendsRepository
                .Setup(repo => repo.AddAsync(It.IsAny<FriendRequest>()))
                .Returns(Task.CompletedTask);
            var requestDto = new FriendRequestRequestDto { ReceiverEmail = "receiver@example.com" };

            // Act
            var result = await _controller.SendRequest(requestDto);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Suggestions", redirectResult.ActionName);
            _mockFriendsRepository.Verify(
                repo => repo.AddAsync(It.IsAny<FriendRequest>()),
                Times.Once
            );
        }

        #endregion

        #region Requests Tests

        [Fact]
        public async Task Requests_WhenUserNotFound_ReturnsUnauthorized()
        {
            // Arrange
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync((User)null!);

            // Act
            var result = await _controller.Requests();

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task Requests_Success_ReturnsViewWithRequests()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var otherUser = new User { Id = "user2", Email = "other@example.com" };

            var requests = new List<FriendRequest>
            {
                new FriendRequest
                {
                    Id = Guid.NewGuid(),
                    Sender = otherUser,
                    Receiver = currentUser,
                    Status = FriendRequestStatus.Pending,
                },
                new FriendRequest
                {
                    Id = Guid.NewGuid(),
                    Sender = currentUser,
                    Receiver = otherUser,
                    Status = FriendRequestStatus.Pending,
                },
            };

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockFriendsRepository
                .Setup(repo => repo.GetAllUserFriendRequestsAsync(currentUser))
                .ReturnsAsync(requests);

            // Act
            var result = await _controller.Requests();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<FriendRequestsViewModel>(viewResult.Model);
            Assert.Single(viewModel.ReceivedRequests);
            Assert.Single(viewModel.SentRequests);
        }

        #endregion

        #region UpdateRequestStatus Tests

        [Fact]
        public async Task UpdateRequestStatus_WhenUserNotFound_ReturnsUnauthorized()
        {
            // Arrange
            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync((User)null!);

            // Act
            var result = await _controller.UpdateRequestStatus(Guid.NewGuid(), "accept");

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task UpdateRequestStatus_RequestNotFound_ReturnsNotFound()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var requestId = Guid.NewGuid();

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockFriendsRepository
                .Setup(repo => repo.GetFriendRequestAsync(requestId))
                .ReturnsAsync((FriendRequest)null!);

            // Act
            var result = await _controller.UpdateRequestStatus(requestId, "accept");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task UpdateRequestStatus_CancelRequest_Success()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var otherUser = new User { Id = "user2", Email = "other@example.com" };
            var requestId = Guid.NewGuid();

            var request = new FriendRequest
            {
                Id = requestId,
                Sender = currentUser,
                Receiver = otherUser,
                Status = FriendRequestStatus.Pending,
            };

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockFriendsRepository
                .Setup(repo => repo.GetFriendRequestAsync(requestId))
                .ReturnsAsync(request);
            _mockFriendsRepository
                .Setup(repo => repo.DeleteAsync(request))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateRequestStatus(requestId, "cancel");

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Requests", redirectResult.ActionName);
            _mockFriendsRepository.Verify(repo => repo.DeleteAsync(request), Times.Once);
        }

        [Fact]
        public async Task UpdateRequestStatus_CancelRequest_NotSender_ReturnsForbid()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var otherUser = new User { Id = "user2", Email = "other@example.com" };
            var requestId = Guid.NewGuid();

            var request = new FriendRequest
            {
                Id = requestId,
                Sender = otherUser, // Current user is not the sender
                Receiver = currentUser,
                Status = FriendRequestStatus.Pending,
            };

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockFriendsRepository
                .Setup(repo => repo.GetFriendRequestAsync(requestId))
                .ReturnsAsync(request);

            // Act
            var result = await _controller.UpdateRequestStatus(requestId, "cancel");

            // Assert
            Assert.IsType<ForbidResult>(result);
        }

        [Fact]
        public async Task UpdateRequestStatus_AcceptRequest_Success()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var otherUser = new User { Id = "user2", Email = "other@example.com" };
            var requestId = Guid.NewGuid();

            var request = new FriendRequest
            {
                Id = requestId,
                Sender = otherUser,
                Receiver = currentUser,
                Status = FriendRequestStatus.Pending,
            };

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockFriendsRepository
                .Setup(repo => repo.GetFriendRequestAsync(requestId))
                .ReturnsAsync(request);

            // Act
            var result = await _controller.UpdateRequestStatus(requestId, "accept");

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Requests", redirectResult.ActionName);
            Assert.Equal(FriendRequestStatus.Accepted, request.Status);
            _mockFriendsRepository.Verify(repo => repo.UpdateAsync(request), Times.Once);
        }

        [Fact]
        public async Task UpdateRequestStatus_DeclineRequest_Success()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var otherUser = new User { Id = "user2", Email = "other@example.com" };
            var requestId = Guid.NewGuid();

            var request = new FriendRequest
            {
                Id = requestId,
                Sender = otherUser,
                Receiver = currentUser,
                Status = FriendRequestStatus.Pending,
            };

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockFriendsRepository
                .Setup(repo => repo.GetFriendRequestAsync(requestId))
                .ReturnsAsync(request);

            // Act
            var result = await _controller.UpdateRequestStatus(requestId, "decline");

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Requests", redirectResult.ActionName);
            Assert.Equal(FriendRequestStatus.Declined, request.Status);
            _mockFriendsRepository.Verify(repo => repo.UpdateAsync(request), Times.Once);
        }

        [Fact]
        public async Task UpdateRequestStatus_NotReceiver_ReturnsForbid()
        {
            // Arrange
            var currentUser = new User { Id = "user1", Email = _userEmail };
            var otherUser1 = new User { Id = "user2", Email = "other1@example.com" };
            var otherUser2 = new User { Id = "user3", Email = "other2@example.com" };
            var requestId = Guid.NewGuid();

            var request = new FriendRequest
            {
                Id = requestId,
                Sender = otherUser1,
                Receiver = otherUser2, // Current user is not the receiver
                Status = FriendRequestStatus.Pending,
            };

            _mockUsersRepository
                .Setup(repo => repo.GetUserByEmailAsync(_userEmail))
                .ReturnsAsync(currentUser);
            _mockFriendsRepository
                .Setup(repo => repo.GetFriendRequestAsync(requestId))
                .ReturnsAsync(request);

            // Act
            var result = await _controller.UpdateRequestStatus(requestId, "accept");

            // Assert
            Assert.IsType<ForbidResult>(result);
        }

        #endregion
    }
}
