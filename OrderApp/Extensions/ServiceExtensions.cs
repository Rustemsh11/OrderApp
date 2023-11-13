using Microsoft.EntityFrameworkCore;
using OrderApp.Contract;
using OrderApp.Repository;
using OrderApp.Service;
using OrderApp.Service.Contract;

namespace OrderApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderAppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
    }
}
