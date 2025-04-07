using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UniMate2.Controllers;
using UniMate2.Models.Domain;
using UniMate2.Repositories;
using Xunit;

namespace UniMate2.Tests.Controllers
{
    public class LikeControllerTests
    {
        private readonly Mock<IUsersRepository> _mockUsersRepository;
        private readonly Mock<ILikeRepository> _mockLikeRepository;
        private readonly LikeController _controller;
        private readonly string _currentUserId = "user-123";
        private readonly string _likedUserId = "user-456";

        public LikeControllerTests()
        {
            _mockUsersRepository = new Mock<IUsersRepository>();
            _mockLikeRepository = new Mock<ILikeRepository>();
            _controller = new LikeController(
                _mockUsersRepository.Object,
                _mockLikeRepository.Object
            );

            // Setup default user claims
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[] { new Claim(ClaimTypes.NameIdentifier, _currentUserId) }
                )
            );

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user },
            };
        }

        [Fact]
        public async Task Create_ValidRequest_AddsLikeAndReturnsRedirect()
        {
            // Arrange
            var currentUser = new User { Id = _currentUserId };
            var likedUser = new User { Id = _likedUserId };

            _mockLikeRepository
                .Setup(repo => repo.LikeExistsAsync(_currentUserId, _likedUserId))
                .ReturnsAsync(false);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByIdAsync(_currentUserId))
                .ReturnsAsync(currentUser);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByIdAsync(_likedUserId))
                .ReturnsAsync(likedUser);

            // Act
            var result = await _controller.Create(_likedUserId);

            // Assert
            _mockLikeRepository.Verify(repo => repo.AddAsync(It.IsAny<Like>()), Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Suggestions", redirectResult.ActionName);
            Assert.Equal("Users", redirectResult.ControllerName);
        }

        [Fact]
        public async Task Create_EmptyLikedUserId_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.Create(string.Empty);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Liked user ID is required", badRequestResult.Value);
        }

        [Fact]
        public async Task Create_LikingSelf_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.Create(_currentUserId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("You cannot like yourself.", badRequestResult.Value);
        }

        [Fact]
        public async Task Create_AlreadyLiked_ReturnsOkResult()
        {
            // Arrange
            _mockLikeRepository
                .Setup(repo => repo.LikeExistsAsync(_currentUserId, _likedUserId))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Create(_likedUserId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var anonymousObject = okResult.Value;

            // Use reflection to access the property instead of serialization
            var messageProperty = anonymousObject.GetType().GetProperty("message");
            Assert.NotNull(messageProperty);
            var messageValue = messageProperty.GetValue(anonymousObject);
            Assert.Equal("Already liked this user.", messageValue);
        }

        [Fact]
        public async Task Create_CurrentUserNotFound_ReturnsNotFound()
        {
            // Arrange
            _mockLikeRepository
                .Setup(repo => repo.LikeExistsAsync(_currentUserId, _likedUserId))
                .ReturnsAsync(false);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByIdAsync(_currentUserId))
                .ReturnsAsync((User)null);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByIdAsync(_likedUserId))
                .ReturnsAsync(new User { Id = _likedUserId });

            // Act
            var result = await _controller.Create(_likedUserId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("User not found", notFoundResult.Value);
        }

        [Fact]
        public async Task Create_LikedUserNotFound_ReturnsNotFound()
        {
            // Arrange
            _mockLikeRepository
                .Setup(repo => repo.LikeExistsAsync(_currentUserId, _likedUserId))
                .ReturnsAsync(false);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByIdAsync(_currentUserId))
                .ReturnsAsync(new User { Id = _currentUserId });
            _mockUsersRepository
                .Setup(repo => repo.GetUserByIdAsync(_likedUserId))
                .ReturnsAsync((User)null);

            // Act
            var result = await _controller.Create(_likedUserId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("User not found", notFoundResult.Value);
        }

        [Fact]
        public async Task Create_AjaxRequest_ReturnsJsonResult()
        {
            // Arrange
            var currentUser = new User { Id = _currentUserId };
            var likedUser = new User { Id = _likedUserId };

            _mockLikeRepository
                .Setup(repo => repo.LikeExistsAsync(_currentUserId, _likedUserId))
                .ReturnsAsync(false);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByIdAsync(_currentUserId))
                .ReturnsAsync(currentUser);
            _mockUsersRepository
                .Setup(repo => repo.GetUserByIdAsync(_likedUserId))
                .ReturnsAsync(likedUser);

            // Set up headers to simulate AJAX request
            _controller.ControllerContext.HttpContext.Request.Headers["X-Requested-With"] =
                "XMLHttpRequest";

            // Act
            var result = await _controller.Create(_likedUserId);

            // Assert
            _mockLikeRepository.Verify(repo => repo.AddAsync(It.IsAny<Like>()), Times.Once);
            var jsonResult = Assert.IsType<JsonResult>(result);
            var anonymousObject = jsonResult.Value;

            // Use reflection to access the property instead of serialization
            var successProperty = anonymousObject.GetType().GetProperty("success");
            Assert.NotNull(successProperty);
            var successValue = successProperty.GetValue(anonymousObject);
            Assert.True((bool)successValue);
        }

        [Fact]
        public async Task Create_NoUserAuthenticated_ReturnsUnauthorized()
        {
            // Arrange - Create a controller with no authenticated user
            var controller = new LikeController(
                _mockUsersRepository.Object,
                _mockLikeRepository.Object
            );
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal() },
            };

            // Act
            var result = await controller.Create(_likedUserId);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
