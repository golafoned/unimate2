using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniMate2.Data;
using UniMate2.Models.Domain;
using UniMate2.Repositories;
using UniMate2.Tests.Helpers;
using Xunit;

namespace UniMate2.Tests.Repositories
{
    public class EventsRepositoryTests
    {
        [Fact]
        public async Task GetAllEvents_ShouldReturnAllEvents()
        {
            // Arrange
            using var context = ServerDbContextFactory.Create();
            var repository = new EventsRepository(context);

            var expectedEvents = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Test Event 1",
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(1).AddHours(2),
                    Description = "Test Description 1",
                    Location =
                        "Test Location 1" // Add required Location property
                    ,
                    // Add other required properties
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Test Event 2",
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(2).AddHours(3),
                    Description = "Test Description 2",
                    Location =
                        "Test Location 2" // Add required Location property
                    ,
                    // Add other required properties
                },
            };

            await context.Events.AddRangeAsync(expectedEvents);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllEvents();

            // Assert
            Assert.Equal(5, result.Count);
            Assert.Contains(result, e => e.Title == "Test Event 1");
            Assert.Contains(result, e => e.Title == "Test Event 2");
        }
    }
}
