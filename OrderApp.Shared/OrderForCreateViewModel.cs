namespace OrderApp.Shared
{
    public class OrderForCreateViewModel
    {
        public int OrderId { get; set; }
        public string? NumberOrder { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public string? Unit { get; set; } 
    }
}
