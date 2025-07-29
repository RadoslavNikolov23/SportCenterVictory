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
        public Guid EventId { get; set; }

        public virtual Event Event { get; set; } = null!;

        [Comment("Shows if EventUser entry is deleted")]
        public bool IsDeleted { get; set; }

    }
}
