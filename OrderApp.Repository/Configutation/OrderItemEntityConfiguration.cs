using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApp.Entity.Models;

namespace OrderApp.Repository.Configutation
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Quantity).HasPrecision(18, 3);
        }
    }
}
