using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UniMate2.Controllers;
using UniMate2.Models.Domain;
using UniMate2.Models.DTO;
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

        [Fact]
        public async Task Index_WithSearchTerm_ReturnsFilteredEvents()
        {
            // Arrange
            var mockUserManager = UserManagerMock.CreateMock();
            var mockEventsRepository = new Mock<IEventsRepository>();

            var searchTerm = "Workshop";
            var events = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Workshop Event",
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(1).AddHours(2),
                    Description = "Workshop Description",
                    Location = "Workshop Location",
                },
            };

            mockEventsRepository.Setup(repo => repo.SearchEvents(searchTerm)).ReturnsAsync(events);

            var controller = new EventsController(
                mockUserManager.Object,
                mockEventsRepository.Object
            );

            // Act
            var result = await controller.Index("asc", searchTerm) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var resultEvents = result.Model as IEnumerable<Event>;
            Assert.NotNull(resultEvents);
            Assert.Single(resultEvents);
            Assert.Equal("Workshop Event", resultEvents.First().Title);
            Assert.Equal(searchTerm, result.ViewData["SearchTerm"]);
        }

        [Fact]
        public void Create_Get_ReturnsView()
        {
            // Arrange
            var mockUserManager = UserManagerMock.CreateMock();
            var mockEventsRepository = new Mock<IEventsRepository>();

            var controller = new EventsController(
                mockUserManager.Object,
                mockEventsRepository.Object
            );

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Model); // No model should be passed for GET
        }

        [Fact]
        public async Task Create_Post_WithValidModel_RedirectsToIndex()
        {
            // Arrange
            var mockUserManager = UserManagerMock.CreateMock();
            var mockEventsRepository = new Mock<IEventsRepository>();

            var eventDto = new EventDto
            {
                Title = "New Event",
                StartDate = DateTime.Now.AddDays(5),
                EndDate = DateTime.Now.AddDays(5).AddHours(2),
                Description = "New Event Description",
                Location = "New Event Location",
            };

            var createdEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = eventDto.Title,
                StartDate = eventDto.StartDate,
                EndDate = eventDto.EndDate,
                Description = eventDto.Description,
                Location = eventDto.Location,
            };

            mockEventsRepository.Setup(repo => repo.AddEvent(eventDto)).ReturnsAsync(createdEvent);

            var controller = new EventsController(
                mockUserManager.Object,
                mockEventsRepository.Object
            );

            // Act
            var result = await controller.Create(eventDto) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            mockEventsRepository.Verify(repo => repo.AddEvent(eventDto), Times.Once);
        }

        [Fact]
        public async Task Create_Post_WithInvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var mockUserManager = UserManagerMock.CreateMock();
            var mockEventsRepository = new Mock<IEventsRepository>();

            var eventDto = new EventDto
            {
                Title = string.Empty,
                Description = string.Empty,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Location = string.Empty,
            };

            var controller = new EventsController(
                mockUserManager.Object,
                mockEventsRepository.Object
            );

            // Add model error to simulate validation failure
            controller.ModelState.AddModelError("Title", "Title is required");

            // Act
            var result = await controller.Create(eventDto) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(eventDto, result.Model);
            mockEventsRepository.Verify(repo => repo.AddEvent(It.IsAny<EventDto>()), Times.Never);
        }

        [Fact]
        public async Task Delete_WithExistingId_RedirectsToIndex()
        {
            // Arrange
            var mockUserManager = UserManagerMock.CreateMock();
            var mockEventsRepository = new Mock<IEventsRepository>();

            var eventId = Guid.NewGuid();
            mockEventsRepository.Setup(repo => repo.DeleteEvent(eventId)).ReturnsAsync(true);

            var controller = new EventsController(
                mockUserManager.Object,
                mockEventsRepository.Object
            );

            // Act
            var result = await controller.Delete(eventId) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            mockEventsRepository.Verify(repo => repo.DeleteEvent(eventId), Times.Once);
        }

        [Fact]
        public async Task Delete_WithNonExistingId_ReturnsNotFound()
        {
            // Arrange
            var mockUserManager = UserManagerMock.CreateMock();
            var mockEventsRepository = new Mock<IEventsRepository>();

            var nonExistingId = Guid.NewGuid();
            mockEventsRepository.Setup(repo => repo.DeleteEvent(nonExistingId)).ReturnsAsync(false);

            var controller = new EventsController(
                mockUserManager.Object,
                mockEventsRepository.Object
            );

            // Act
            var result = await controller.Delete(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            mockEventsRepository.Verify(repo => repo.DeleteEvent(nonExistingId), Times.Once);
        }
    }
}
