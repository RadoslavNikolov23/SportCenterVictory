namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Entity representing the many-to-many relationship between ApplicationUser and Trainer.")]
    public class TrainerUser
    {
        [Comment("Foreign key to the referenced ApplicationUser. Part of the entity composite PK.")]
        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [Comment("Foreign key to the referenced Trainer. Part of the entity composite PK.")]
        public Guid TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; } = null!;

        //Removed the addition informating and add IsDelete property

        [Comment("Indicates whether the TrainerUser entity is deleted. Soft delete flag.")]
        public bool IsDeleted { get; set; }
    }
}
