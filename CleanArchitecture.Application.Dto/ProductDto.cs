﻿namespace CleanArchitecture.Application.Dto
{
    public class ProductDto
    {
        public long ProductId { get; set; }
        public string? Name { get; set; }
        public string? StatusName { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
