using UniMate2.Models.Domain;
using UniMate2.Models.DTO;

namespace UniMate2.Repositories;

public interface IEventsRepository
{
    Task<List<Event>> GetAllEvents();
    Task<List<Event>> SearchEvents(string searchTerm);
    Task<Event?> GetEventById(Guid id);
    Task<Event> AddEvent(EventDto eventDto);
    Task<bool> DeleteEvent(Guid id);
}
