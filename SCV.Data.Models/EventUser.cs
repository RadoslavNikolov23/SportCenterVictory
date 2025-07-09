namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents a user who has purchased a membership.")]
    public class EventUser
    {
        [Comment("Foreign key to the referenced ApplicationUser. Part of the entity composite PK.")]
        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [Comment("Foreign key to the referenced Event. Part of the entity composite PK.")]
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;

    }
}
