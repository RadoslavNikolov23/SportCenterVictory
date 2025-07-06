namespace SCV.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [Comment("Application user model that extends IdentityUser")]
    public class ApplicationUser:IdentityUser
    {
        [Comment("Full name of the user")]
        public string FullName { get; set; } = null!;

        [Comment("The date the user is register On the site")]
        public DateTime RegisteredOn { get; set; }

        [Comment("Collection of orders for the user")]
        public virtual ICollection<Order> OrdersUsers { get; set; } = new HashSet<Order>();

        [Comment("Collection of CrossFit Classes the user is attending")]
        public virtual ICollection<CrossfitClass> CrossfitClassesUsers { get; set; } = new HashSet<CrossfitClass>();

        [Comment("Collection of the Memberships/Programs the user has joined.")]
        public virtual ICollection<MembershipUser> MembershipUsers { get; set; } = new HashSet<MembershipUser>();

        [Comment("Collection of the User's Trainers/Coaches.")]
        public virtual ICollection<TrainerUser> TrainerUsers { get; set; } = new HashSet<TrainerUser>();

        [Comment("Collection of the User's Feedbacks")]
        public virtual ICollection<UserFeedback> UserFeedbacks { get; set; } = new HashSet<UserFeedback>();




    }
}
