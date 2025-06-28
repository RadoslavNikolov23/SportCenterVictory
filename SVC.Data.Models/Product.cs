namespace SVC.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!; // Equipment / Nutrition / Plan
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; } 
    }
}
