namespace SCV.Data.Seeding.DTOs
{
    using SCV.GlCommon.Enums;
    using System.ComponentModel.DataAnnotations;

    using static SCV.GlCommon.ModelConstants.EntityConstantsTrainer;


    public class TrainerDTO
    {

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(BioMaxLength, MinimumLength = BioMinLength)]

        public string Bio { get; set; } = null!;

        [Required]
        public SportType TrainerSpecialty { get; set; }

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        [Url]
        public string? ImageUrl { get; set; }
    }
}
