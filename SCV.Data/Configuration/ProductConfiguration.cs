namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SVC.Data.Models;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            //entity.HasKey(p => p.Id);

            //entity.Property(p => p.Title)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //entity.Property(p => p.Description)
            //    .HasMaxLength(1000);

            //entity.Property(p => p.Category)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //entity.Property(p => p.Price)
            //    .HasColumnType("decimal(18,2)");

            //entity.Property(p => p.ImageUrl)
            //    .HasMaxLength(300);

            //entity.HasData(new Product
            //{
            //    Id = 1,
            //    Title = "Weightlifting Belt",
            //    Description = "High quality leather lifting belt for support.",
            //    Category = "Equipment",
            //    Price = 45.00m,
            //    ImageUrl = "/images/products/belt.jpg"
            //});
        }
    }
}
