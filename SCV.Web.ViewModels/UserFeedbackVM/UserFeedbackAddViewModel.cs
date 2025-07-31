namespace SCV.Web.ViewModels.UserFeedbackVM
{
    using SCV.GlCommon.Enums;
    using System.ComponentModel.DataAnnotations;

    using static SCV.GlCommon.ModelConstants.EntityConstantsUserFeedback;
    using static SCV.GlCommon.ValidationMessages.UserFeedback;

    public class UserFeedbackAddViewModel
    {
        [Required(ErrorMessage = UserIdRequired)]
        public string UserId { get; set; } = null!;

        [Required(ErrorMessage = UserNameRequired)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = UserNameLength)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = FullNameRequired)]
        [StringLength(UserFullNameMaxLength, MinimumLength = UserFullNameMinLength, ErrorMessage = FullNameLength)]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = FeedbackRequired)]
        [StringLength(FeedbackMaxLength, MinimumLength = FeedbackMinLength, ErrorMessage = FeedbackLength)]
        public string Feedback { get; set; } = null!;

        public FeedbackStatus Status { get; set; }

        [Url(ErrorMessage = ImageUrlInvalid)]
        [StringLength(ImageUrlMaxLength, ErrorMessage = ImageUrlInvalid)]
        public string? ImageUrl { get; set; }
    }
}
