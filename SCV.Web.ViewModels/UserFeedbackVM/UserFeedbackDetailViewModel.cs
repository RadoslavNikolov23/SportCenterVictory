namespace SCV.Web.ViewModels.UserFeedbackVM
{
    public class UserFeedbackDetailViewModel
    {
        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Feedback { get; set; } = null!;

        public string? ImageUrl { get; set; }

    }
}
