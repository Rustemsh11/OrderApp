using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApp.Entity.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
