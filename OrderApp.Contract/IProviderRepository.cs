using OrderApp.Entity.Models;

namespace OrderApp.Contract
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> GetProvidersAsync(bool trackChanges);
    }
}
