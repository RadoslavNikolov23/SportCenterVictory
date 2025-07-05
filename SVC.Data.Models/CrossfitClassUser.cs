namespace SVC.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class CrossfitClassUser
    {
        [Comment("Foreign key to the referenced ApplicationUser. Part of the entity composite PK.")]
        public string ApplicationUserId { get; set; } = null!;

        public IdentityUser ApplicationUser { get; set; } = null!;

        [Comment("Foreign key to the referenced CrossfitClass. Part of the entity composite PK.")]
        public int CrossfitClassId { get; set; };

        public CrossfitClass CrossfitClass { get; set; } = null!;

        [Comment("The date and time when the user joined the class")]
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    }
}
