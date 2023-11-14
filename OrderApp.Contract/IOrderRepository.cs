using OrderApp.Entity.Models;

namespace OrderApp.Contract
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

        /// <summary>
        /// получаем по уникальным ключам конкретный заказ
        /// </summary>
        Task<Order> GetOrderByNumberAndProviderIdAsync(string number, int providerId, bool trackChanges);
        Task<IEnumerable<Order>> GetAllOrders(bool trackChanges);
        Task<IEnumerable<Order>> GetAllOrdersWithOrderDetails(bool trackChanges);
        Task<Order> GetOrderById(int id, bool trackChanges);
        void DeleteOrder(Order order);
    }
}
