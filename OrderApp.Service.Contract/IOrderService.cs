using OrderApp.Entity.Models;
using OrderApp.Shared;

namespace OrderApp.Service.Contract
{
    public interface IOrderService
    {
        Task CreateOrder(OrderForCreateViewModel orderViewModel);
        Task<Order> GetOrderByNumberAndProviderId(string number, int providerId, bool trackChanges);
        Task<IEnumerable<Order>> GetAllOrders(bool trackChanges);
        Task<Order> GetOrderById(int id, bool trackChanges);
    }
}
