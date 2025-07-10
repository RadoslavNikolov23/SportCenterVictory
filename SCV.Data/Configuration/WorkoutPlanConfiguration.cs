namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstantsWorkoutPlan;
    using static SCV.GlCommon.ApplicationConstants;

    public class WorkoutPlanConfiguration : BaseConfiguration, IEntityTypeConfiguration<WorkoutPlan>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlan> entity)
        {
            entity
                .HasKey(wp => wp.Id);

            entity
                .Property(wp => wp.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            entity
                .Property(wp => wp.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(wp => wp.Type)
                .IsRequired();

            entity
                .Property(wp => wp.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(wp => wp.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(wp => wp.IsDeleted==false);

            entity.HasData(SeedFromJson<WorkoutPlan>(Path.Combine("..", "SCV.Data", "SeedFiles", "WorkoutPlans", "workoutPlansSeed.json")));
        }
    }
}
