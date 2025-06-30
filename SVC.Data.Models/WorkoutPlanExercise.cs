namespace SVC.Data.Models
{
    public class WorkoutPlanExercise
    {
        public string ExerciseId { get; set; } = null!;

        public Exercise Exercise { get; set; } = null!;

        public int WorkoutPlanId { get; set; } 

        public WorkoutPlan WorkoutPlan { get; set; } = null!;

    }
}
