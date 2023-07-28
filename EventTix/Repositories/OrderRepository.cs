using System;
using EventTix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Api.Exceptions;

namespace EventTix.Repositories
{
	public class OrderRepository : IOrderRepository
	{
        private readonly PracticaContext _dbContext;
        public OrderRepository(PracticaContext practicaContext)
		{
            _dbContext = practicaContext;

        }

        public int Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order @order)
        {
            _dbContext.Remove(@order);
            _dbContext.SaveChanges();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var @order = await _dbContext.Orders
                                         .Include(e => e.Customer)
                                         .Include(e => e.TicketCategory)
                                         .Where(e => e.OrderId == id)
                                         .FirstOrDefaultAsync() ?? throw new EntityNotFoundException(id, nameof(Order));
            return @order;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _dbContext.Orders.Include(e => e.Customer).Include(e => e.TicketCategory);
            return orders;
        }

        public void Update(Order @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

