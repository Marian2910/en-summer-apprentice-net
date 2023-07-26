using System;
using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventTix.Controllers 
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> getAllOrders()
        {
            var dtoOrders = _orderRepository.GetOrders().Select(_mapper.Map<OrderDto>);
            dtoOrders.Select(e => e.EventName = _eventRepository.GetEventById(e.EventId).EventName);
            return Ok(dtoOrders);

        }

        [HttpGet]
        public ActionResult<OrderDto> getById(int id)
        {
            var @order = _orderRepository.GetOrderById(id);
            if (@order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(@order);
            orderDto.EventName = _eventRepository.GetEventById(@order.TicketCategory.EventId)?
                                                 .EventName ?? string.Empty;
            return Ok(orderDto);
        }
    }
}



