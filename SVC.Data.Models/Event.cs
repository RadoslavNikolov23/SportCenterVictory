namespace SVC.Data.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Category { get; set; } = null!;// Fitness / CrossFit / Powerlifting
        public DateTime StartDate { get; set; }
        public string Location { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
