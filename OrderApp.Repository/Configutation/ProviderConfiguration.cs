using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApp.Entity.Models;

namespace OrderApp.Repository.Configutation
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.Property(c=>c.Id).ValueGeneratedOnAdd();

            builder.HasData(new Provider               
                {
                    Id = 1,
                    Name = "Alibaba"
                });
            builder.HasData(
                new Provider()
                {
                    Id = 2,
                    Name = "Amazon"
                });
            builder.HasData(
                new Provider()
                {
                    Id = 3,
                    Name = "eBay"
                });
            builder.HasData(
                new Provider()
                {
                    Id = 4,
                    Name = "Wallmart"
                });
            
        }
    }
}
