namespace SVC.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using SCV.GlCommon.Enums;
    using System.Data.Common;

    public class Membership
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public MembershipType MembershipType { get; set; }

        public MembershipTier MembershipTier { get; set; }

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string Duration { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; } = null!;

        public ICollection<MembershipUser> MembershipUsers { get; set; } = new HashSet<MembershipUser>();

    }
}
