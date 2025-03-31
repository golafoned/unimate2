using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories;

public class EventsRepository(ServerDbContext context) : IEventsRepository
{
    private readonly ServerDbContext _context = context;

    public async Task<List<Event>> GetAllEvents()
    {
        return await _context.Events.ToListAsync();
    }
}
