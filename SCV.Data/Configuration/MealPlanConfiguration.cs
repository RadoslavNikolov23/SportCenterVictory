namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SVC.Data.Models;

    public class MealPlanConfiguration : IEntityTypeConfiguration<MealPlan>
    {
        public void Configure(EntityTypeBuilder<MealPlan> builder)
        {
            builder.HasKey(mp => mp.Id);

            builder.Property(mp => mp.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(mp => mp.DietType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(mp => mp.Description)
                .HasMaxLength(1000);

            builder.Property(mp => mp.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasData(new MealPlan
            {
                Id = 1,
                Title = "Lean Bulk High Protein Plan",
                DietType = "Muscle Gain",
                Description = "Meal plan focused on lean muscle building with high-protein meals.",
                Price = 19.99m
            });
        }
    }
}
