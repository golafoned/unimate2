using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http; // Add this using statement
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using UniMate2.Controllers;
using UniMate2.Data;
using UniMate2.Models;
using UniMate2.Models.Domain;
using UniMate2.Tests.Helpers;
using Xunit;

namespace UniMate2.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithUserNames()
        {
            // Arrange
            var logger = new Mock<ILogger<HomeController>>();
            var userManagerMock = UserManagerMock.CreateMock();

            var users = new List<User>
            {
                new User { UserName = "user1" },
                new User { UserName = "user2" },
            }.AsQueryable();

            userManagerMock.Setup(um => um.Users).Returns(users);

            using var context = ServerDbContextFactory.Create();
            var controller = new HomeController(userManagerMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var userNames = result.Model as List<string>;
            Assert.NotNull(userNames);
            Assert.Equal(2, userNames.Count);
            Assert.Contains("user1", userNames);
            Assert.Contains("user2", userNames);
        }

        [Fact]
        public void Error_ReturnsErrorView()
        {
            // Arrange
            var logger = new Mock<ILogger<HomeController>>();
            var userManagerMock = UserManagerMock.CreateMock();

            using var context = ServerDbContextFactory.Create();
            var controller = new HomeController(userManagerMock.Object);

            // Set up HttpContext to prevent null reference exception
            var httpContext = new DefaultHttpContext();
            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };

            // Act
            var result = controller.Error() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ErrorViewModel>(result.Model);
        }
    }
}
