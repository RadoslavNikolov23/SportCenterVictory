namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Workout Plan Exercise entity representing an exercise within a workout plan")]
    public class WorkoutPlanExercise
    {
        [Comment("Foreign key to the referenced Exercise. Part of the entity composite PK.")]

        public string ExerciseId { get; set; } = null!;

        public virtual Exercise Exercise { get; set; } = null!;

        [Comment("Foreign key to the referenced WorkoutPlan. Part of the entity composite PK.")]

        public Guid WorkoutPlanId { get; set; }

        public virtual WorkoutPlan WorkoutPlan { get; set; } = null!;

    }
}
