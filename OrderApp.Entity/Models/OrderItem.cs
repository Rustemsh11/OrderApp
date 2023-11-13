using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApp.Entity.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Name { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Unit { get; set; }
        
        public Order? Order { get; set; }

    }
}
