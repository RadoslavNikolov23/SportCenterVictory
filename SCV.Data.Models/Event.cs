namespace SCV.Data.Models
{
    using SCV.GlCommon.Enums;
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents an event in the web application, such as a fitness, crossfit or powerlifting competition or training session.")]
    public class Event
    {
        [Comment("Primary Key for the event")]
        public int Id { get; set; }

        [Comment("Title of the event, e.g., 'CrossFit Regional Challenge'")]
        public string Title { get; set; } = null!;

        [Comment("Type of the event - Fitness, CrossFit, Powerlifting")]
        public SportType EventType { get; set; }

        [Comment("Detailed description of the event, e.g., 'A local competition for intermediate-level CrossFitters.'")]
        public string? Description { get; set; }

        [Comment("Start date and time of the event")]
        public DateTime StartDate { get; set; }

        [Comment("Location of the event, e.g., 'Sport Center Victory - Ruse'")]
        public string Location { get; set; } = null!;

        [Comment("URL of the event image")]
        public string? ImageUrl { get; set; }

        [Comment("Indicates if the event is deleted (soft delete)")]
        public bool IsDeleted { get; set; }

        [Comment("Collection of Events the users wants to join.")]
        public virtual ICollection<EventUser> EventUsers { get; set; } = new HashSet<EventUser>();
    }
}
