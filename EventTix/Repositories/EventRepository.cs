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

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Event GetEventById(int id)
        {
            var @event = _dbContext.Events.Include(e=>e.EventType).Include(e=>e.Venue).SingleOrDefault(e => e.EventId == id);
            return @event;
        }

        public IEnumerable<Event> GetEvents()
        {
            var events = _dbContext.Events.Include(e => e.EventType).Include(e => e.Venue);
            return events;
        }

        public void Update(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}

