namespace SVC.Data.Models
{
    using SCV.GlCommon.Enums;

    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public EventType EventType { get; set; } // Fitness / CrossFit / Powerlifting

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public string Location { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}
