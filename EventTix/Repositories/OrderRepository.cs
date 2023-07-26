using System;
using EventTix.Models;
using Microsoft.EntityFrameworkCore;

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

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            var order = _dbContext.Orders.Include(e => e.Customer).Include(e => e.TicketCategory).SingleOrDefault(e => e.OrderId == id);
            return order;

        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _dbContext.Orders.Include(e => e.Customer).Include(e => e.TicketCategory);
            return orders;
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

