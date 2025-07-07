namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents a user who has purchased a membership.")]
    public class MembershipUser
    {
        [Comment("Foreign key to the referenced ApplicationUser. Part of the entity composite PK.")]
        public string ApplicationUserId { get; set; } = null!;

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [Comment("Foreign key to the referenced Membership. Part of the entity composite PK.")]
        public int MembershipId { get; set; }

        public virtual Membership Membership { get; set; } = null!;

        [Comment("The date and time when the membership was purchased.")]
        public DateOnly PurchasedOn { get; set; }

        [Comment("Indicates whether the membership user is deleted. Used for soft deletion.")]
        public bool IsDeleted { get; set; }
    }
}
