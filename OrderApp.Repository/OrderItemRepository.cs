using Microsoft.EntityFrameworkCore;
using OrderApp.Contract;
using OrderApp.Entity.Models;

namespace OrderApp.Repository
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OrderAppDbContext orderAppDbContext) : base(orderAppDbContext)
        {
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            Create(orderItem);
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
            Delete(orderItem);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderId(int orderId, bool trackChanges)
        {
            return await FindByConditions(c => c.OrderId == orderId, trackChanges).Include(c=>c.Order).ToListAsync();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            Update(orderItem);
        }
    }
}
