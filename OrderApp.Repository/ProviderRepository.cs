using Microsoft.EntityFrameworkCore;
using OrderApp.Contract;
using OrderApp.Entity.Models;

namespace OrderApp.Repository
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(OrderAppDbContext orderAppDbContext) : base(orderAppDbContext)
        {
        }

        public async Task<IEnumerable<Provider>> GetProvidersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }
}
