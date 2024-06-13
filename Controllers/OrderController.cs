using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIExample2.DTO;
using WebAPIExample2.IServices;
using WebAPIExample2.Models;

namespace WebAPIExample2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult> GetOrder(int orderId)
        {
            var order = await _orderService.GetOrder(orderId);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound($"Lack of order with id: {orderId}");
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            if (orders != null && orders.Any())
            {
                return Ok(orders);
            }
            return NotFound("Lack of orders");
        }


        [HttpPost]
        public async Task<ActionResult> AddOrder(OrderDTO orderDTO)
        {
            if(await _orderService.AddOrder(orderDTO))
                return Ok(orderDTO);
            return NotFound("Something is gone wrong with your order. Check data");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder(OrderDTO orderDTO)
        {
            var existingOrder = await _orderService.GetOrder(orderDTO.OrderId);
            if (existingOrder == null)
            {
                return NotFound("There is no order like this one");
            }

            await _orderService.UpdateOrder(orderDTO);
            return Ok("The part has been updated");
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            var existingOrder = await _orderService.GetOrder(orderId);
            if (existingOrder == null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrder(orderId);
            return NoContent();
        }
    }
}
