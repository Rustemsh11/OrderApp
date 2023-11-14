using AutoMapper;
using OrderApp.Contract;
using OrderApp.Entity.Models;
using OrderApp.Service.Contract;
using OrderApp.Shared;
using System.Data;
using System.Linq;

namespace OrderApp.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderItemService(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task CreateOrderItem(OrderForCreateViewModel order)
        {
            var orderItem = _mapper.Map<OrderItem>(order);            
            _repositoryManager.OrderItemRepository.CreateOrderItem(orderItem);
            await _repositoryManager.SaveAsync();
        }

        public async Task CreateRangeOrderItem(IEnumerable<OrderForCreateViewModel> order)
        {
            
            var createdOrder = await _repositoryManager.OrderRepository.GetOrderByNumberAndProviderIdAsync(order.FirstOrDefault().NumberOrder, order.FirstOrDefault().ProviderId, false);
            foreach (var orderItem in order)
            {
                if(createdOrder.Number == orderItem.Name)
                {
                    throw new Exception("Номер заказа и имя детали заказа не может быть одинаковым");
                }
                var item = _mapper.Map<OrderItem>(orderItem);
                item.OrderId = createdOrder.Id;
                _repositoryManager.OrderItemRepository.CreateOrderItem(item);
            }
            await _repositoryManager.SaveAsync();
        }

        /// <summary>
        /// ВОзвращает true если был удален последний Item
        /// false если под этим orderId еще существуют items
        /// </summary>
        public async Task<bool> DeleteOrderItem(int id, int orderId, bool trackCHanges)
        {
            var orderItems = await _repositoryManager.OrderItemRepository.GetOrderItemsByOrderId(orderId, trackCHanges);
            if (orderItems is null)
            {
                throw new ArgumentNullException(nameof(orderItems));
            }
            var currentItem = orderItems.SingleOrDefault(c=>c.Id == id);

            if(currentItem is null)
            {
                throw new ArgumentNullException(nameof(currentItem));
            }

            _repositoryManager.OrderItemRepository.DeleteOrderItem(currentItem);

            if (orderItems.Count() == 1)
            {
                var order = await _repositoryManager.OrderRepository.GetOrderById(orderId, trackCHanges);
                _repositoryManager.OrderRepository.DeleteOrder(order);
                await _repositoryManager.SaveAsync();
                return true;
            }

            await _repositoryManager.SaveAsync();
            return false;
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItems(bool trackChanges)
        {
            var orderItems = await _repositoryManager.OrderItemRepository.GetAllOrderItems(trackChanges);
            if(orderItems is null)
            {
                throw new ArgumentNullException(nameof(orderItems));
            }
            return orderItems;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderId(int id, bool trackChanges)
        {
            var orderItem = await _repositoryManager.OrderItemRepository.GetOrderItemsByOrderId(id, trackChanges);

            if(orderItem == null) 
            {
                throw new NullReferenceException(nameof(orderItem));                
            }
            return orderItem;
        }

        public async Task UpdateOrderItems(IEnumerable<OrderItem> orderItems)
        {
           foreach (var orderItem in orderItems)
            {
                _repositoryManager.OrderItemRepository.UpdateOrderItem(orderItem);
            }
            await _repositoryManager.SaveAsync();
        }
    }
}
