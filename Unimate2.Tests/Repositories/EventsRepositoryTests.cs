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
            using var context = ServerDbContextFactory.Create(); // Цей контекст включатиме початкові дані (seeded events)
            var repository = new EventsRepository(context);

            // Події, специфічні для цього тесту
            var testSpecificEvents = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Test Event 1",
                    StartDate = DateTime.UtcNow.AddDays(1), // Використання UtcNow для узгодженості
                    EndDate = DateTime.UtcNow.AddDays(1).AddHours(2),
                    Description = "Test Description 1",
                    Location = "Test Location 1",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Test Event 2",
                    StartDate = DateTime.UtcNow.AddDays(2), // Використання UtcNow
                    EndDate = DateTime.UtcNow.AddDays(2).AddHours(3),
                    Description = "Test Description 2",
                    Location = "Test Location 2",
                },
            };

            await context.Events.AddRangeAsync(testSpecificEvents);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllEvents();

            // Assert
            // Кількість початкових подій - 12 (згідно з останніми змінами в ServerDbContext)
            // Плюс 2 події, додані в цьому тесті.
            int numberOfSeededEvents = 12; 
            int totalExpectedEvents = numberOfSeededEvents + testSpecificEvents.Count;

            Assert.Equal(totalExpectedEvents, result.Count);
            Assert.Contains(result, e => e.Title == "Test Event 1");
            Assert.Contains(result, e => e.Title == "Test Event 2");
            // Додатково можна перевірити наявність деяких початкових подій
            Assert.Contains(result, e => e.Title == "Community Meetup");
        }
    }
}
