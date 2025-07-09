namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SCV.Data.Models;
    using static SCV.Data.Common.EntityConstantsProduct;
    using static SCV.GlCommon.ApplicationConstants;


    public class ProductConfiguration : BaseConfiguration, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            entity 
                .Property(p => p.ProductCategory)
                .IsRequired();

            entity
                .Property(p => p.Quantity)
                .IsRequired();

            entity
                .Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType(PriceSqlType);

            entity
                .Property(p => p.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                 .Property(m => m.IsDeleted)
                 .HasDefaultValue(false);

            entity
                .HasQueryFilter(e => e.IsDeleted == false);

            //entity.HasData(SeedFromJson<Product>(Path.Combine("..", "SeedFiles", "Products", "productsSeed.json")));
        }
    }
}
