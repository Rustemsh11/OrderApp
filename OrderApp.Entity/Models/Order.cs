using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApp.Entity.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Number { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? Date { get; set; }
        public int? ProviderId { get; set; } 

        public Provider? Provider { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set;}
    }
}
