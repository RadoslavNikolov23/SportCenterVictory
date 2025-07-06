namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Entity representing the many-to-many relationship between ApplicationUser and Trainer.")]
    public class TrainerUser
    {
        [Comment("Foreign key to the referenced ApplicationUser. Part of the entity composite PK.")]
        public string ApplicationUserId { get; set; } = null!;

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [Comment("Foreign key to the referenced Trainer. Part of the entity composite PK.")]
        public int trainerId { get; set; }

        public virtual Trainer Trainer { get; set; } = null!;

        [Comment("Additional information about which course/membership/plan is the user attached to the trainer")]
        public string? AdditionalInformation { get; set; }
    }
}
