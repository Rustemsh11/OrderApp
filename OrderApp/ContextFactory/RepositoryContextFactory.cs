using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrderApp.Repository;

namespace OrderApp.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<OrderAppDbContext>
    {
        public OrderAppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<OrderAppDbContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("OrderApp"));
            return new OrderAppDbContext(builder.Options);
        }
    }
}
