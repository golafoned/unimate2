using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UniMate2.Controllers;
using UniMate2.Models.Domain;
using UniMate2.Repositories;
using UniMate2.Tests.Helpers;
using Xunit;

namespace UniMate2.Tests.Controllers
{
    public class EventsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithEvents_OrderedAscendingByDefault()
        {
            // Arrange
            var mockUserManager = UserManagerMock.CreateMock();
            var mockEventsRepository = new Mock<IEventsRepository>();

            var events = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 1",
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(2).AddHours(2),
                    Description = "Test Description 1",
                    Location = "Test Location 1",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 2",
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(1).AddHours(2),
                    Description = "Test Description 2",
                    Location = "Test Location 2",
                },
            };

            mockEventsRepository.Setup(repo => repo.GetAllEvents()).ReturnsAsync(events);

            var controller = new EventsController(
                mockUserManager.Object,
                mockEventsRepository.Object
            );

            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var resultEvents = result.Model as IEnumerable<Event>;
            Assert.NotNull(resultEvents);

            // Check events are ordered ascending by StartDate
            var orderedEvents = resultEvents.ToList();
            Assert.Equal("Event 2", orderedEvents[0].Title);
            Assert.Equal("Event 1", orderedEvents[1].Title);
        }

        [Fact]
        public async Task Index_ReturnsViewWithEvents_OrderedDescending()
        {
            // Arrange
            var mockUserManager = UserManagerMock.CreateMock();
            var mockEventsRepository = new Mock<IEventsRepository>();

            var events = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 1",
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(2).AddHours(2),
                    Description = "Test Description 1",
                    Location = "Test Location 1",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Event 2",
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(1).AddHours(2),
                    Description = "Test Description 2",
                    Location = "Test Location 2",
                },
            };

            mockEventsRepository.Setup(repo => repo.GetAllEvents()).ReturnsAsync(events);

            var controller = new EventsController(
                mockUserManager.Object,
                mockEventsRepository.Object
            );

            // Act
            var result = await controller.Index("desc") as ViewResult;

            // Assert
            Assert.NotNull(result);
            var resultEvents = result.Model as IEnumerable<Event>;
            Assert.NotNull(resultEvents);

            // Check events are ordered descending by StartDate
            var orderedEvents = resultEvents.ToList();
            Assert.Equal("Event 1", orderedEvents[0].Title);
            Assert.Equal("Event 2", orderedEvents[1].Title);
        }
    }
}
