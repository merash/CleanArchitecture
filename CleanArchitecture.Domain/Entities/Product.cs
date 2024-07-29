namespace CleanArchitecture.Domain.Entities
{
    public class Product
    {
        public long ProductId { get; set; }
        public required string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
    }
}
