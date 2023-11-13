using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApp.Entity.Models;

namespace OrderApp.Repository.Configutation
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c=>c.Id).ValueGeneratedOnAdd();

            builder.HasIndex(c => new { c.Number, c.ProviderId }).IsUnique();
        }
    }
}
