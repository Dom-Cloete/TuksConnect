using TuksConnectAPI.Models;

namespace TuksConnectAPI.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event?> GetEventById(int id);
        Task<Event> AddEvent(Event eventItem);
        Task<Event?> UpdateEvent(Event eventItem);
        Task<bool> DeleteEvent(int id);
    }
}