namespace SCV.Web.ViewModels.CommonVM
{
    using SCV.GlCommon.Enums;
    using System.ComponentModel.DataAnnotations;

    public class TrainerDetailViewModel
    {
        public Guid Id { get; set; } 

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        public string Bio { get; set; } = null!;

        public SportType TrainerSpecialty { get; set; }

        public string? ImageUrl { get; set; }

        public virtual ICollection<MembershipsTrainerViewModel> MembershipsByTrainer { get; set; } = new HashSet<MembershipsTrainerViewModel>();
    }

    public class MembershipsTrainerViewModel
    {
        public string Name { get; set; } = null!;

        public SportType MembershipType { get; set; }

        public MembershipTier MembershipTier { get; set; }

    }
}
