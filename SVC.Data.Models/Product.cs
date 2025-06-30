namespace SVC.Data.Models
{
    using SCV.GlCommon.Enums;

    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ProductCategory ProductCategory { get; set; }

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; } 

        public bool IsDeleted { get; set; } // Indicates if the product is currently available

    }
}
