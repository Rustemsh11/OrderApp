using OrderApp.Entity.Models;

namespace OrderApp.Service.Contract
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetProvidersAsync(bool trackChanges);
    }
}
