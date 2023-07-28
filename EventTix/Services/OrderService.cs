using System;
using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EventTix.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;


        public OrderService(IOrderRepository orderRepository,IEventRepository eventRepository,
                            ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _eventRepository = eventRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }

        public List<OrderDto> GetAll()
        {
            var orders = _orderRepository.GetOrders().Select(_mapper.Map<OrderDto>).ToList();
            
            return orders;
        }

        public async Task<OrderDto> GetById(int id)
        {
            var @order = await _orderRepository.GetOrderById(id);
            var orderDto = _mapper.Map<OrderDto>(@order);
            var @event = await _eventRepository.GetEventById(@order.TicketCategory.EventId);
            orderDto.EventName = @event?.EventName ?? string.Empty;

            return orderDto;
        }

        public async Task<Order> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetOrderById(orderPatch.OrderId);

            var @event = await _eventRepository.GetEventById(orderEntity.TicketCategory.EventId);
            var ticketCategory = await _ticketCategoryRepository.GetTicketCategoryByDescriptionAndEvent(orderPatch.TicketCategory, @event.EventId);

            if (!orderPatch.TicketCategory.IsNullOrEmpty()) orderEntity.TicketCategoryId = ticketCategory.TicketCategoryId;

            orderEntity.OrderedAt = DateTime.Now;
            orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            orderEntity.TotalPrice = (orderPatch.NumberOfTickets * ticketCategory.Price);
            _orderRepository.Update(orderEntity);

            var updatedOrder = await _orderRepository.GetOrderById(orderPatch.OrderId);

            return updatedOrder;
        }

        public async Task<Order> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetOrderById(id);
            _orderRepository.Delete(orderEntity);
            return orderEntity;
        }

    }
}
