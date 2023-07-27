using System;
using EventTix.Models;
using EventTix.Models.Dto;

namespace EventTix.Services
{
	public interface IOrderService
	{
        public List<OrderDto> GetAll();

        public Task<OrderDto> GetById(int id);

        public Task<Order> Patch(OrderPatchDto orderPatch);

        public Task<Order> Delete(int id);
    }
}
