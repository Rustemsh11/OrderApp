using OrderApp.Entity.Models;
using OrderApp.Shared;

namespace OrderApp.Service.Contract
{
    public interface IOrderItemService
    {
        Task CreateOrderItem(OrderForCreateViewModel order);
        Task CreateRangeOrderItem(IEnumerable<OrderForCreateViewModel> order);
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderId(int id, bool trackChanges);
        Task<IEnumerable<OrderItem>> GetAllOrderItems(bool trackChanges);
        Task UpdateOrderItems(IEnumerable<OrderItem> orderItems);
        Task<bool> DeleteOrderItem(int id, int orderId, bool trackChanges);
    }
}
