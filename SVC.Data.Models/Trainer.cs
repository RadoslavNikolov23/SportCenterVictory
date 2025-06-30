namespace SVC.Data.Models
{
    using SCV.GlCommon.Enums;

    public class Trainer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string Bio { get; set; } = null!;

        public TrainerSpecialty Specialty { get; set; } // Fitness / CrossFit / Powerlifting

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Membership> Memberships { get; set; } = new HashSet<Membership>();




    }
}
