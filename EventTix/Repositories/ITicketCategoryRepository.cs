using System;
using EventTix.Models;

namespace EventTix.Repositories
{
	public interface ITicketCategoryRepository
	{
        Task<TicketCategory> GetTicketCategoryByDescriptionAndEvent(string description, int eventId);
        Task<TicketCategory> GetTicketCategoryById(int id);

    }
}

