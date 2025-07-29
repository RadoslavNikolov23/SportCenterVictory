namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    using SCV.GlCommon.Enums;

    [Comment("Represents a membership in the web application, for the fitness, crossfit and powerlifting.")]
    public class Membership
    {
        [Comment("Primary Key for the membership.")]
        public Guid Id { get; set; }

        [Comment("Name of the membership")]
        public string Name { get; set; } = null!;

        [Comment("Type of the membership - Fitness, CrossFit, Powerlifting.")]
        public SportType MembershipType { get; set; }

        [Comment("Description of the membership.")]
        public string Description { get; set; } = null!;

        [Comment("Price of the membership.")]
        public decimal Price { get; set; }

        [Comment("Duration of the membership - '1 month', '3 months', '1 year'.")]
        public string Duration { get; set; } = null!;

        [Comment("Indicates whether the membership is deleted.")]
        public bool IsDeleted { get; set; }

        [Comment("Collection of MembershipUsers associated with this membership.")]
        public virtual ICollection<MembershipUser> MembershipUsers { get; set; } = new HashSet<MembershipUser>();

    }
}
