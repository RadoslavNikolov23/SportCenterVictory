namespace SCV.Data.Models
{
    using SCV.GlCommon.Enums;
    using Microsoft.EntityFrameworkCore;

    [Comment("Workout Plan entity for a structured workout plan for fitness, crossFit or powerlifting")]
    public class WorkoutPlan
    {
        [Comment("Primary key for the workout plan")]
        public int Id { get; set; }

        [Comment("Title of the workout plan, e.g., 'Push/Pull/Legs'")]
        public string Title { get; set; } = null!;

        [Comment("Description of the workout plan")]
        public string Description { get; set; } = null!;

        [Comment("Type of the workout plan - 'CrossFit', 'Powerlifting', 'Bodybuilding'")]
        public SportType Type { get; set; }

        [Comment("Optional image URL for the workout plan")]
        public string? ImageUrl { get; set; }

        [Comment("Price of the workout plan, null if free")]
        public decimal? Price { get; set; }

        [Comment("Indicates if the workout plan is currently active or deleted")]
        public bool IsDeleted { get; set; }

        [Comment("Collection of exercises associated with the workout plan")]
        public virtual ICollection<WorkoutPlanExercise> WorkoutPlanExercises { get; set; } = new HashSet<WorkoutPlanExercise>();

    }
}
