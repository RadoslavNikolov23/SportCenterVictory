namespace SCV.Web.ViewModels.CommonVM
{
    using SCV.Data.Models;
    using SCV.GlCommon.Enums;

    public class TrainerViewModel
    {
        public Guid Id { get; set; } 

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string Bio { get; set; } = null!;

        public SportType TrainerSpecialty { get; set; }

        public string? ImageUrl { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; } = new HashSet<Membership>();
    }

    public class MembershipsTrainerViewModel
    {
        public string Name { get; set; } = null!;

        public SportType MembershipType { get; set; }

        public MembershipTier MembershipTier { get; set; }



    }
}
