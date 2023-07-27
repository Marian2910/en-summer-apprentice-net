using System;
using EventTix.Models;

namespace EventTix.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();

        Task<Order> GetOrderById(int id);

        int Add(Order @order);

        void Update(Order @order);

        void Delete(Order @order);

    }
}

