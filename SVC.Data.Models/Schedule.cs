namespace SVC.Data.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!; // CrossFit / Powerlifting
        public DateTime Date { get; set; }
        public string WorkoutOfTheDay { get; set; } = null!;
    }
}
