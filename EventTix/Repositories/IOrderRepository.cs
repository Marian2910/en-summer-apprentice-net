using System;
using EventTix.Models;

namespace EventTix.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();

        Order GetOrderById(int id);

        int Add(Order @order);

        void Update(Order @order);

        int Delete(int id);

    }
}

