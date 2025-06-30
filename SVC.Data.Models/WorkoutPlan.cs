namespace SVC.Data.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;


        public string Type { get; set; } = null!; // Fitness / CrossFit / Powerlifting

        public string? ImageUrl { get; set; } // Optional image URL

        public decimal? Price { get; set; } // Null if free

        public bool IsDeleted { get; set; } // Indicates if the workout plan is currently active

        public ICollection<WorkoutPlanExercise> WorkoutPlanExercises { get; set; } = new HashSet<WorkoutPlanExercise>();

    }
}
