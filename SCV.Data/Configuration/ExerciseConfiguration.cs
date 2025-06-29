namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SVC.Data.Models;

    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> entity)
        {
            entity.HasKey(ex => ex.Id);

            entity.Property(ex => ex.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(ex => ex.MuscleGroup)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(ex => ex.Description)
                .HasMaxLength(1000);

            entity.Property(ex => ex.ImageUrl)
                .HasMaxLength(300);

            entity.HasData(new Exercise
            {
                Id = 1,
                Name = "Barbell Squat",
                MuscleGroup = "Legs",
                Description = "Compound movement that targets the quadriceps, glutes, and hamstrings.",
                ImageUrl = "https://youtube.com/example/barbell-squat"
            });
        }
    }
}
