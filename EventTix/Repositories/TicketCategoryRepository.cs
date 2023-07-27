using System;
using EventTix.Models;
using Microsoft.EntityFrameworkCore;

namespace EventTix.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly PracticaContext _dbContext;

        public TicketCategoryRepository(PracticaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TicketCategory> GetTicketCategoryByDescriptionAndEvent(string description, int eventId)
        {
            var @ticketCategory = await _dbContext.TicketCategories.Where(e => (e.Description == description && e.EventId == eventId)).FirstOrDefaultAsync();
                return @ticketCategory;
        }
    }
}

