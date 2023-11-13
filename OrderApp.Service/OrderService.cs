using AutoMapper;
using OrderApp.Contract;
using OrderApp.Entity.Models;
using OrderApp.Service.Contract;
using OrderApp.Shared;

namespace OrderApp.Service
{
    public class OrderService: IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
               
        public async Task CreateOrder(OrderForCreateViewModel orderViewModel)
        {
            
            var order = _mapper.Map<Order>(orderViewModel);            
            _repositoryManager.OrderRepository.CreateOrder(order);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders(bool trackChanges)
        {
            var orders = await _repositoryManager.OrderRepository.GetAllOrders(trackChanges);
            if(orders == null)
            {
                throw new NullReferenceException(nameof(orders));
            }
            return orders;
        }

        public async Task<Order> GetOrderById(int id, bool trackChanges)
        {
            var order = await _repositoryManager.OrderRepository.GetOrderById(id, trackChanges);
            if (order == null)
            {
                throw new NullReferenceException(nameof(order));
            }
            return order;
        }

        public async Task<Order> GetOrderByNumberAndProviderId(string number, int providerId, bool trackChanges)
        {
            var order = await _repositoryManager.OrderRepository.GetOrderByNumberAndProviderIdAsync(number, providerId, trackChanges);
            if (order == null)
            {
                throw new NullReferenceException(nameof(order));
            }
            return order;
        }
    }
}
