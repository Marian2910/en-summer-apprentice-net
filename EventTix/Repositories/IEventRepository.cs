using System;
using EventTix.Models;

namespace EventTix.Repositories
{
	public interface IEventRepository
	{
		IEnumerable<Event> GetEvents();

		Event GetEventById(int id);

		int Add(Event @event);

		void Update(Event @event);

		int Delete(int id);

	}
}

