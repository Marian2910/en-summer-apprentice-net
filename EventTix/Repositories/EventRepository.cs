using EventTix.Models;
using Microsoft.EntityFrameworkCore;

namespace EventTix.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly PracticaContext _dbContext;

        public EventRepository(PracticaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public async Task<Event> GetEventById(int id)
        {
            var @event = await _dbContext.Events.Include(e=>e.EventType).Include(e=>e.Venue).Where(e => e.EventId == id).FirstOrDefaultAsync();
            return @event;
        }

        public IEnumerable<Event> GetEvents()
        {
            var events = _dbContext.Events.Include(e => e.EventType).Include(e => e.Venue);
            return events;
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

