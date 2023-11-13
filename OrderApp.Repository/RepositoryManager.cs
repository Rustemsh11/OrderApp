using OrderApp.Contract;

namespace OrderApp.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly OrderAppDbContext _context;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IOrderItemRepository> _orderItemRepository;
        private readonly Lazy<IProviderRepository> _providerRepositiry;
        public RepositoryManager(OrderAppDbContext context)
        {
            _context = context;
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(context));
            _orderItemRepository = new Lazy<IOrderItemRepository>(() => new OrderItemRepository(context));
            _providerRepositiry = new Lazy<IProviderRepository>(() => new ProviderRepository(context));
        }



        public IOrderRepository OrderRepository => _orderRepository.Value;

        public IOrderItemRepository OrderItemRepository =>_orderItemRepository.Value;

        public IProviderRepository ProviderRepository => _providerRepositiry.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
