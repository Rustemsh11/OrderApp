using OrderApp.Contract;
using OrderApp.Entity.Models;
using OrderApp.Service.Contract;

namespace OrderApp.Service
{
    public class ProviderService : IProviderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProviderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Provider>> GetProvidersAsync(bool trackChanges)
        {
            return await _repositoryManager.ProviderRepository.GetProvidersAsync(trackChanges);
        }
    }
}
