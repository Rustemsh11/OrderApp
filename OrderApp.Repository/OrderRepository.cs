using Microsoft.EntityFrameworkCore;
using OrderApp.Contract;
using OrderApp.Entity.Models;

namespace OrderApp.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderAppDbContext orderAppDbContext) : base(orderAppDbContext)
        {
        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrders(bool trackChanges)
        {
            return await FindAll(trackChanges).Include(c=>c.Provider).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithOrderDetails(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Include(c => c.Provider)
                .Include(c => c.OrderItems).ToListAsync();
        }

        public async Task<Order> GetOrderById(int id, bool trackChanges)
        {
            return await FindByConditions(c => c.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Order> GetOrderByNumberAndProviderIdAsync(string number, int providerId, bool trackChanges)
        {
            return await FindByConditions(c => c.Number == number && c.ProviderId == providerId, trackChanges).SingleOrDefaultAsync();
        }
    }
}
