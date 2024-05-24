using WebAPIExample2.Models;

namespace WebAPIExample2.IServices
{
    public interface IOrderService
    {
        public Task<Order> GetOrder(int orderId);
        public Task<bool> AddOrder(Order orderModel);
        public Task<bool> UpdateOrder(Order orderModel);
        public Task<bool> DeleteOrder(int orderId);
    }
}
