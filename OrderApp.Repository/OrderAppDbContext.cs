using Microsoft.EntityFrameworkCore;
using OrderApp.Entity.Models;
using OrderApp.Repository.Configutation;

namespace OrderApp.Repository
{
    public class OrderAppDbContext : DbContext
    {
        public OrderAppDbContext(DbContextOptions options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}
