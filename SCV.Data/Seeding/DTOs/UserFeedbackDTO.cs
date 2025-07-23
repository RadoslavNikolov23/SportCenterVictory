namespace SCV.Data.Seeding.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static SCV.GlCommon.ModelConstants.EntityConstantsUserFeedback;
    public class UserFeedbackDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]

        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(FeedbackMaxLength, MinimumLength = FeedbackMinLength)]
        public string Feedback { get; set; } = null!;

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string? ImageUrl { get; set; }
    }
}
