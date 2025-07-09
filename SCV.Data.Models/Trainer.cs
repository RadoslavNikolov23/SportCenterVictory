namespace SCV.Data.Models
{
    using SCV.GlCommon.Enums;
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents a personal trainer in the web application. Can be a fitness, crossfit or powerlifting trainer/coach.")]
    public class Trainer
    {

        [Comment("Primary key for the Trainer entity.")]
        public Guid Id { get; set; }

        [Comment("First name of the trainer.")]
        public string FirstName { get; set; } = null!;

        [Comment("Last name of the trainer.")]
        public string LastName { get; set; } = null!;

        [Comment("Email address of the trainer. Must be unique.")]
        public string Email { get; set; } = null!;

        [Comment("Phone number of the trainer. Optional, can be null.")]
        public string? PhoneNumber { get; set; }

        [Comment("Short biography of the trainer, describing their experience and qualifications.")]
        public string Bio { get; set; } = null!;

        [Comment("Specialty of the trainer, indicating their area of expertise (e.g., Fitness, CrossFit, Powerlifting).")]
        public SportType TrainerSpecialty { get; set; } // Fitness / CrossFit / Powerlifting

        [Comment("URL of the trainer's profile image. Optional, can be null.")]
        public string? ImageUrl { get; set; }

        [Comment("Indicates whether the trainer is marked as deleted. Used for soft deletion.")]
        public bool IsDeleted { get; set; }

        [Comment("Foreign key so that the user can be identify as a trainer/coach.")]
        public Guid? ApplicationUserId { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

        [Comment("Collection of TrainerUser entities that associate trainers with application users.")]
        public virtual ICollection<TrainerUser> TrainerUsers { get; set; } = new HashSet<TrainerUser>();

        [Comment("Collection of Membership entities that link trainers to memberships they manage.")]
        public virtual ICollection<Membership> Memberships { get; set; } = new HashSet<Membership>();

    }
}
