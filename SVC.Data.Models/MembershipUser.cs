namespace SVC.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class MembershipUser
    {

        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;

        public int MembershipId { get; set; }

        public Membership Membership { get; set; } = null!;

        public DateTime PurchasedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
