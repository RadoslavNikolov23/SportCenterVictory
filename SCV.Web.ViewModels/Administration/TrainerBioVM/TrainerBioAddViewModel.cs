namespace SCV.Web.ViewModels.Administration.TrainerBioVM
{
    using SCV.GlCommon.Enums;

    using System.ComponentModel.DataAnnotations;

    using static SCV.GlCommon.ModelConstants.EntityConstantsTrainer;
    using static SCV.GlCommon.ValidationMessages.Trainer;

    public class TrainerBioAddViewModel
    {
        [Required(ErrorMessage = FirstNameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FirstNameLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LastNameLength)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = EmailRequired)]
        [EmailAddress(ErrorMessage = EmailInvalid)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = EmailLength)]
        public string Email { get; set; } = null!;

        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = PhoneNumberLength)]
        [Phone(ErrorMessage = PhoneNumberInvalid)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = BioRequired)]
        [StringLength(BioMaxLength, MinimumLength = BioMinLength, ErrorMessage = BioLength)]

        public string Bio { get; set; } = null!;

        [Required(ErrorMessage = TrainerSpecialtyRequired)]
        public SportType TrainerSpecialty { get; set; }

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = ImageUrlInvalid)]
        [Url(ErrorMessage = ImageUrlInvalid)]
        public string? ImageUrl { get; set; }

        public string? ApplicationUserId { get; set; }
    }
}
