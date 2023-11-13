namespace OrderApp.Contract
{
    public interface IRepositoryManager
    {
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IProviderRepository ProviderRepository { get; }
        Task SaveAsync();
    }
}
