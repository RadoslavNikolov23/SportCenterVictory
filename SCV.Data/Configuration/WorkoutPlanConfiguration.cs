namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SVC.Data.Models;

    public class WorkoutPlanConfiguration : IEntityTypeConfiguration<WorkoutPlan>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlan> entity)
        {
            entity.HasKey(w => w.Id);

            entity.Property(w => w.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(w => w.Description)
                .HasMaxLength(1000);

            entity.Property(w => w.Type)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(w => w.Price)
                .HasColumnType("decimal(18,2)");

            entity.Property(w => w.DurationWeeks)
                .IsRequired();

            // Optional: seed
            entity.HasData(new WorkoutPlan
            {
                Id = 1,
                Title = "Beginner Strength",
                Description = "4-week beginner-friendly strength training program.",
                Type = "Fitness",
                DurationWeeks = 4,
                Price = 29.99m
            });
        }
    }
}
