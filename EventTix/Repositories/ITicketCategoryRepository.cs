using EventTix.Models;

namespace EventTix.Repositories
{
	public interface ITicketCategoryRepository
	{
        Task<TicketCategory> GetTicketCategoryByDescriptionAndEventId(string description, int eventId);
        Task<TicketCategory> GetTicketCategoryById(int id);

    }
}

