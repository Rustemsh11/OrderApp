using OrderApp.Entity.Models;

namespace OrderApp.Contract
{
    public interface IOrderItemRepository
    {
        void CreateOrderItem(OrderItem orderItem);
        Task<IEnumerable<OrderItem>> GetAllOrderItems(bool trackChanges);
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderId(int orderId, bool trackChanges);
        void UpdateOrderItem(OrderItem orderItems);
        void DeleteOrderItem(OrderItem orderItem);
    }
}
