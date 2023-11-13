namespace OrderApp.Shared
{
    public record OrderViewModel
    {
        public int Id { get; init; }
        public string? Number { get; init; }
        public DateTime Date { get; init; }
        public string? ProviderName { get; init; }
    }
}
