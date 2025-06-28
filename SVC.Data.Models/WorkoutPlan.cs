namespace SVC.Data.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!; // Fitness / CrossFit / Powerlifting
        public int DurationWeeks { get; set; }
        public decimal? Price { get; set; } // Null if free
    }
}
