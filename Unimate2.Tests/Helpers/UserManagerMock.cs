using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using UniMate2.Models.Domain;

namespace UniMate2.Tests.Helpers
{
    public static class UserManagerMock
    {
        public static UserManager<User> Create()
        {
            var store = new Mock<IUserStore<User>>();
            var optionsAccessor = new Mock<IOptions<IdentityOptions>>();
            var passwordHasher = new Mock<IPasswordHasher<User>>();
            var userValidators = new List<IUserValidator<User>>();
            var passwordValidators = new List<IPasswordValidator<User>>();
            var keyNormalizer = new Mock<ILookupNormalizer>();
            var errors = new Mock<IdentityErrorDescriber>();
            var services = new Mock<IServiceProvider>();
            var logger = new Mock<ILogger<UserManager<User>>>();

            return new UserManager<User>(
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
        }

        public static Mock<UserManager<User>> CreateMock()
        {
            var store = new Mock<IUserStore<User>>();
            var mockUserManager = new Mock<UserManager<User>>(
                store.Object,
                Mock.Of<IOptions<IdentityOptions>>(),
                Mock.Of<IPasswordHasher<User>>(),
                new List<IUserValidator<User>> { new UserValidator<User>() },
                new List<IPasswordValidator<User>> { new PasswordValidator<User>() },
                Mock.Of<ILookupNormalizer>(),
                new IdentityErrorDescriber(),
                Mock.Of<IServiceProvider>(),
                Mock.Of<ILogger<UserManager<User>>>()
            );

            mockUserManager
                .Setup(x => x.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            mockUserManager
                .Setup(x => x.DeleteAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            mockUserManager
                .Setup(x => x.UpdateAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            mockUserManager
                .Setup(x => x.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            mockUserManager
                .Setup(x => x.RemoveFromRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            return mockUserManager;
        }
    }
}
