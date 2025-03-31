using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public interface IEventsRepository
    {
        Task<List<Event>> GetAllEvents();
    }
}
