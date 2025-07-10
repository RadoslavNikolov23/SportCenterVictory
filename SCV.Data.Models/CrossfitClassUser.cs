namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents a many-to-many relationship between ApplicationUser and CrossfitClass.")]
    public class CrossfitClassUser
    {
        [Comment("Foreign key to the referenced ApplicationUser. Part of the entity composite PK.")]
        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [Comment("Foreign key to the referenced CrossfitClass. Part of the entity composite PK.")]
        public int CrossfitClassId { get; set; }

        public virtual CrossfitClass CrossfitClass { get; set; } = null!;

        [Comment("The date and time when the user joined the class")]
        public DateTime JoinedAt { get; set; }

    }
}
