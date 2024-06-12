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
            return Ok(await _orderService.GetOrder(orderId));
        }
        [HttpGet]
        [Route("Orders")]

        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _orderService.GetOrders());
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
            var existingService = await _orderService.GetOrder(orderDTO.OrderId);
            if (existingService == null)
            {
                return NotFound();
            }

            await _orderService.UpdateOrder(orderDTO);
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            var existingService = await _orderService.GetOrder(orderId);
            if (existingService == null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrder(orderId);
            return NoContent();
        }
    }
}
