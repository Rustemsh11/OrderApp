using AutoMapper;
using OrderApp.Contract;
using OrderApp.Service.Contract;

namespace OrderApp.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<IOrderItemService> _orderItemService;
        private readonly Lazy<IProviderService> _providerService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {

            _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager,mapper));
            _orderItemService = new Lazy<IOrderItemService>(() => new OrderItemService(repositoryManager, mapper));
            _providerService = new Lazy<IProviderService>(() => new ProviderService(repositoryManager));
        }

        public IOrderService OrderService => _orderService.Value;   

        public IOrderItemService OrderItemService => _orderItemService.Value;

        public IProviderService ProviderService => _providerService.Value;
    }
}
