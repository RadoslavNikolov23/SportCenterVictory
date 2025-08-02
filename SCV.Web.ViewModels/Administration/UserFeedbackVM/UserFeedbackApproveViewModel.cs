namespace SCV.Web.ViewModels.Administration.UserFeedbackVM
{
    using SCV.GlCommon.Enums;

    public class UserFeedbackApproveViewModel
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Feedback { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public FeedbackStatus Status { get; set; }
    }
}
