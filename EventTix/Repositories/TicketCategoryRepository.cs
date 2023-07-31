using EventTix.Models;
using Microsoft.EntityFrameworkCore;
using TMS.Api.Exceptions;

namespace EventTix.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly PracticaContext _dbContext;

        public TicketCategoryRepository(PracticaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TicketCategory> GetTicketCategoryByDescriptionAndEventId(string description, int eventId)
        {
            var @ticketCategory = await _dbContext.TicketCategories
                                                  .Where(t => t.Description == description && t.EventId == eventId)
                                                  .FirstOrDefaultAsync() ?? throw new EntityNotFoundException(description);
                return @ticketCategory;
        }

        public async Task<TicketCategory> GetTicketCategoryById(int id)
        {
            var ticketCategory = await _dbContext.TicketCategories.Where(t => t.TicketCategoryId == id).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(id, nameof(TicketCategory));
            return ticketCategory;
        }
    }
}

