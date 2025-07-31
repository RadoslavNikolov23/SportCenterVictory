namespace SCV.Data.Seeding.DTOs
{
    using SCV.GlCommon.Enums;
    using System.ComponentModel.DataAnnotations;
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
