using System;
using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Repositories;
using EventTix.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventTix.Controllers 
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAllOrders()
        {
            return Ok(_orderService.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var @order = await _orderService.GetById(id);

            if (@order == null)
            {
                return NotFound();
            }
            return Ok(@order);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {

            var updatedOrder = await _orderService.Patch(orderPatch);
            if (updatedOrder == null)
                return NotFound();

            return NoContent();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedOrder = await _orderService.Delete(id);
            if (deletedOrder == null)
                return NotFound();

            return NoContent();
        }
    }
}



