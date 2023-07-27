using System;
using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventTix.Controllers 
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository, IEventRepository eventRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _eventRepository = eventRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> getAllOrders()
        {
            var dtoOrders = _orderRepository.GetOrders().Select(_mapper.Map<OrderDto>);
            return Ok(dtoOrders);

        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> getById(int id)
        {
            var @order = await _orderRepository.GetOrderById(id);

            if (@order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(@order);
            var @event = await _eventRepository.GetEventById(@order.TicketCategory.EventId);

            orderDto.EventName = @event?.EventName ?? string.Empty;

            return Ok(orderDto);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetOrderById(orderPatch.OrderId);

            if (orderEntity == null)
            {
                return NotFound();
            }

            var @event = await _eventRepository.GetEventById(orderEntity.TicketCategory.EventId);
            var ticketCategory = await _ticketCategoryRepository.GetTicketCategoryByDescriptionAndEvent(orderPatch.TicketCategory, @event.EventId);

            if (!orderPatch.TicketCategory.IsNullOrEmpty()) orderEntity.TicketCategoryId = ticketCategory.TicketCategoryId;

            orderEntity.OrderedAt = DateTime.Now;
            orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            orderEntity.TotalPrice = (orderPatch.NumberOfTickets * ticketCategory.Price);
            _orderRepository.Update(orderEntity);

            return NoContent();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetOrderById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }
    }
}



