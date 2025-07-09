namespace SCV.Data.Models
{
    using SCV.GlCommon.Enums;
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents a product in the web application. Can be an Equipment or a Nutrition product.")]
    public class Product
    {
        [Comment("Primary Key for the product.")]
        public Guid Id { get; set; }

        [Comment("Title of the product, e.g., 'Weightlifting Belt'.")]
        public string Title { get; set; } = null!;

        [Comment("Category of the product - 'Equipment' or 'Nutrition'.")]
        public ProductCategory ProductCategory { get; set; }

        [Comment("Quantity of the product available in stock.")]
        public int Quantity { get; set; }

        [Comment("Description of the product, providing details about its features and benefits.")]
        public string? Description { get; set; }

        [Comment("Price of the product")]
        public decimal Price { get; set; }

        [Comment("URL of the product image, used for displaying the product in the UI.")]
        public string? ImageUrl { get; set; } 

        [Comment("Indicates if the product is currently available for purchase. If true, the product is deleted and not available.")]
        public bool IsDeleted { get; set; } // Indicates if the product is currently available

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}
