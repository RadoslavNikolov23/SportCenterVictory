namespace SVC.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class MembershipUser
    {

        public string ApplicationUserId { get; set; } = null!;

        public IdentityUser ApplicationUser { get; set; } = null!;

        public int MembershipId { get; set; }

        public Membership Membership { get; set; } = null!;

        public DateTime PurchasedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
