namespace SCV.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [Comment("Application user model that extends IdentityUser")]
    public class ApplicationUser:IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Full name of the user")]
        public string FullName { get; set; } = null!;

        [Comment("The date the user is register On the site")]
        public DateTime RegisteredOn { get; set; }

        [Comment("Collection of CrossFit Classes the user is attending")]
        public virtual ICollection<CrossfitClassUser> CrossfitClassesUsers { get; set; } = new HashSet<CrossfitClassUser>();

        [Comment("Collection of Events the user is attending")]
        public virtual ICollection<EventUser> EventUsers { get; set; } = new HashSet<EventUser>();

        [Comment("Collection of the Memberships the user has purchased.")]
        public virtual ICollection<MembershipUser> MembershipUsers { get; set; } = new HashSet<MembershipUser>();

        [Comment("Collection of orders for the user")]
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        [Comment("Collection of the Trainers/Coaches in the Sport Center.")]
        public virtual ICollection<Trainer> Trainers { get; set; } = new HashSet<Trainer>();

        [Comment("Collection of the User's Trainers/Coaches.")]
        public virtual ICollection<TrainerUser> TrainerUsers { get; set; } = new HashSet<TrainerUser>();

        [Comment("Collection of the User's Feedbacks")]
        public virtual ICollection<UserFeedback> UserFeedbacks { get; set; } = new HashSet<UserFeedback>();

    }
}
