using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models.Domain;
using UniMate2.Models.DTO;

namespace UniMate2.Repositories;

public class EventsRepository(ServerDbContext context) : IEventsRepository
{
    private readonly ServerDbContext _context = context;

    public async Task<List<Event>> GetAllEvents()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<List<Event>> SearchEvents(string searchTerm)
    {
        return await _context
            .Events.Where(e =>
                e.Title.Contains(searchTerm)
                || e.Description.Contains(searchTerm)
                || e.Location.Contains(searchTerm)
            )
            .ToListAsync();
    }

    public async Task<Event?> GetEventById(Guid id)
    {
        return await _context.Events.FindAsync(id);
    }

    public async Task<Event> AddEvent(EventDto eventDto)
    {
        var newEvent = new Event
        {
            Id = Guid.NewGuid(),
            Title = eventDto.Title,
            Description = eventDto.Description,
            StartDate = DateTime.SpecifyKind(eventDto.StartDate, DateTimeKind.Utc),
            EndDate = DateTime.SpecifyKind(eventDto.EndDate, DateTimeKind.Utc),
            Location = eventDto.Location,
        };

        await _context.Events.AddAsync(newEvent);
        await _context.SaveChangesAsync();
        return newEvent;
    }

    public async Task<bool> DeleteEvent(Guid id)
    {
        var eventToDelete = await _context.Events.FindAsync(id);
        if (eventToDelete == null)
        {
            return false;
        }

        _context.Events.Remove(eventToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}
