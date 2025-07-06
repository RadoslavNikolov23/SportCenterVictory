namespace SCV.Data.Models
{
    using Microsoft.AspNetCore.Identity;
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

        //Add a property in which can add ifnormation about which course/membership/plan is the user attached to the trainer
    }
}
