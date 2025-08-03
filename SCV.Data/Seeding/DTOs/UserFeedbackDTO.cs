namespace SCV.Data.Seeding.DTOs
{
    using System.ComponentModel.DataAnnotations;

    using SCV.GlCommon.Enums;

    using static SCV.GlCommon.ModelConstants.EntityConstantsUserFeedback;
    public class UserFeedbackDTO
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]

        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(UserFullNameMinLength, MinimumLength = UserFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(FeedbackMaxLength, MinimumLength = FeedbackMinLength)]
        public string Feedback { get; set; } = null!;

        [Required]
        public FeedbackStatus Status { get; set; }

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string? ImageUrl { get; set; }
    }
}
