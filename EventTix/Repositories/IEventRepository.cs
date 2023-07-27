using System;
using EventTix.Models;

namespace EventTix.Repositories
{
	public interface IEventRepository
	{
		IEnumerable<Event> GetEvents();

		Task<Event> GetEventById(int id);

		int Add(Event @event);

		void Update(Event @event);

		void Delete(Event @event);

	}
}

