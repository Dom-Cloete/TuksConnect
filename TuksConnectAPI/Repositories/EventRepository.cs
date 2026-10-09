using Microsoft.EntityFrameworkCore;
using TuksConnectAPI.Data;
using TuksConnectAPI.Models;

namespace TuksConnectAPI.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events
                .OrderByDescending(e => e.Id)
                .ToListAsync();
        }

        public async Task<Event?> GetEventById(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<Event> AddEvent(Event eventItem)
        {
            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();
            return eventItem;
        }

        public async Task<Event?> UpdateEvent(Event eventItem)
        {
            var existing = await _context.Events.FindAsync(eventItem.Id);
            if (existing == null) return null;

            existing.EventTitle = eventItem.EventTitle;
            existing.Location = eventItem.Location;
            existing.TicketPrice = eventItem.TicketPrice;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null) return false;

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
