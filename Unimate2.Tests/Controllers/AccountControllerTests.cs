using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using UniMate2.Controllers;
using UniMate2.Models.Domain;
using UniMate2.Models.ViewModels;
using Xunit;

namespace Unimate2.Tests.Controllers
{
    public class AccountControllerTests
    {
        private readonly Mock<UserManager<User>> _mockUserManager;
        private readonly Mock<SignInManager<User>> _mockSignInManager;
        private readonly Mock<ILogger<AccountController>> _mockLogger;

        public AccountControllerTests()
        {
            // Setup UserManager mock
            _mockUserManager = MockUserManager<User>();

            // Setup SignInManager mock
            _mockSignInManager = MockSignInManager();

            // Setup Logger mock
            _mockLogger = new Mock<ILogger<AccountController>>();
        }

        private static Mock<UserManager<User>> MockUserManager<TUser>()
            where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var optionsAccessor = new Mock<IOptions<IdentityOptions>>();
            var passwordHasher = new Mock<IPasswordHasher<TUser>>();
            var userValidators = new List<IUserValidator<TUser>>();
            var passwordValidators = new List<IPasswordValidator<TUser>>();
            var keyNormalizer = new Mock<ILookupNormalizer>();
            var errors = new Mock<IdentityErrorDescriber>();
            var services = new Mock<IServiceProvider>();
            var logger = new Mock<ILogger<UserManager<TUser>>>();

            var mgr = new Mock<UserManager<TUser>>(
                store.Object,
                optionsAccessor.Object,
                passwordHasher.Object,
                userValidators,
                passwordValidators,
                keyNormalizer.Object,
                errors.Object,
                services.Object,
                logger.Object
            );

            return mgr as Mock<UserManager<User>>;
        }

        private Mock<SignInManager<User>> MockSignInManager()
        {
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<User>>();
            var options = new Mock<IOptions<IdentityOptions>>();
            var logger = new Mock<ILogger<SignInManager<User>>>();
            var schemes = new Mock<IAuthenticationSchemeProvider>();
            var confirmation = new Mock<IUserConfirmation<User>>();

            return new Mock<SignInManager<User>>(
                _mockUserManager.Object,
                contextAccessor.Object,
                userPrincipalFactory.Object,
                options.Object,
                logger.Object,
                schemes.Object,
                confirmation.Object
            );
        }

        #region Register GET Tests

        [Fact]
        public void Register_GET_ReturnsViewResult_WhenUserNotAuthenticated()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            // Set up controller context for unauthenticated user
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext(),
            };

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Register_GET_RedirectsToHome_WhenUserIsAuthenticated()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            // Set up controller context for authenticated user
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[] { new Claim(ClaimTypes.Name, "test@example.com") },
                    "mock"
                )
            );

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user },
            };

            // Act
            var result = controller.Register() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        #endregion

        #region Register POST Tests

        [Fact]
        public async Task Register_POST_ReturnsViewWithModel_WhenModelStateIsInvalid()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            controller.ModelState.AddModelError("Email", "Required");
            var model = new RegisterModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
            };

            // Act
            var result = await controller.Register(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model, result.Model);
        }

        [Fact]
        public async Task Register_POST_ReturnsViewWithErrors_WhenUserCreationFails()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            var model = new RegisterModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
            };

            _mockUserManager
                .Setup(um => um.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(
                    IdentityResult.Failed(
                        new IdentityError { Description = "User creation failed" }
                    )
                );

            // Act
            var result = await controller.Register(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model, result.Model);
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async Task Register_POST_RedirectsToUpdateCurrentUser_WhenSuccessful()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            var model = new RegisterModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
            };

            _mockUserManager
                .Setup(um => um.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            _mockSignInManager
                .Setup(sm => sm.SignInAsync(It.IsAny<User>(), false, null))
                .Returns(Task.CompletedTask);

            // Act
            var result = await controller.Register(model) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("UpdateCurrentUser", result.ActionName);
            Assert.Equal("Users", result.ControllerName);
        }

        #endregion

        #region Login GET Tests

        [Fact]
        public void Login_GET_ReturnsViewResult_WhenUserNotAuthenticated()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            // Set up controller context for unauthenticated user
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext(),
            };

            // Act
            var result = controller.Login();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Login_GET_RedirectsToHome_WhenUserIsAuthenticated()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            // Set up controller context for authenticated user
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[] { new Claim(ClaimTypes.Name, "test@example.com") },
                    "mock"
                )
            );

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user },
            };

            // Act
            var result = controller.Login() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        #endregion

        #region Login POST Tests

        [Fact]
        public async Task Login_POST_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            controller.ModelState.AddModelError("Email", "Required");
            var model = new LoginModel { Email = "test@example.com", Password = "Password123!" };

            // Act
            var result = await controller.Login(model) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model, result.Value);
        }

        [Fact]
        public async Task Login_POST_ReturnsBadRequest_WhenLoginFails()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            var model = new LoginModel { Email = "test@example.com", Password = "Password123!" };

            _mockSignInManager
                .Setup(sm =>
                    sm.PasswordSignInAsync(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<bool>(),
                        It.IsAny<bool>()
                    )
                )
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            // Act
            var result = await controller.Login(model) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model, result.Value);
            Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ContainsKey(string.Empty));
        }

        [Fact]
        public async Task Login_POST_RedirectsToHome_WhenLoginSucceeds()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            var model = new LoginModel { Email = "test@example.com", Password = "Password123!" };

            _mockSignInManager
                .Setup(sm =>
                    sm.PasswordSignInAsync(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<bool>(),
                        It.IsAny<bool>()
                    )
                )
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            // Act
            var result = await controller.Login(model) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        #endregion

        #region Logout Tests

        [Fact]
        public async Task Logout_RedirectsToHome_AfterSignOut()
        {
            // Arrange
            var controller = new AccountController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockLogger.Object
            );

            _mockSignInManager.Setup(sm => sm.SignOutAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await controller.Logout() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
            _mockSignInManager.Verify(sm => sm.SignOutAsync(), Times.Once);
        }

        #endregion
    }
}
