namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WorkoutPlanExerciseConfiguration : IEntityTypeConfiguration<WorkoutPlanExercise>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlanExercise> entity)
        {
            entity
                 .HasKey(wpe => new { wpe.ExerciseId, wpe.WorkoutPlanId });

            entity
                .HasOne(wpe => wpe.Exercise)
                .WithMany(e => e.WorkoutPlanExercises)
                .HasForeignKey(wpe => wpe.ExerciseId);

            entity
                .HasOne(wpe => wpe.WorkoutPlan)
                .WithMany(wp => wp.WorkoutPlanExercises)
                .HasForeignKey(wpe => wpe.WorkoutPlanId);

            entity
                .HasQueryFilter(wpe => wpe.WorkoutPlan.IsDeleted == false);

            //----! Seed after the WorkoutPlan and Exercise entities are configured !----

            //entity.HasData(SeedFromJson<WorkoutPlanExercise>(Path.Combine("..", "SeedFiles", "WorkoutPlanExercises", "workoutPlanExerciseSeed.json")));
        }
    }
}
