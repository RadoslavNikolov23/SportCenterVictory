namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using SCV.GlCommon.Enums;

    [Comment("Represents user feedback in the system.")]
    public class UserFeedback
    {
        [Comment("Primary key for the UserFeedback Table.")]
        public int Id { get; set; }

        [Comment("The name of the user who provided the feedback.")]
        public string UserName { get; set; } = null!;

        [Comment("The context of the feedback.")]
        public string Feedback { get; set; } = null!;

        [Comment("The URL of the image associated with the feedback, if any.")]
        public string? ImageUrl { get; set; }

        [Comment("The status of the feedback, indicating whether it is pending, publish, or removed. The default will be pending.")]
        public FeedbackStatus Status { get; set; }

        [Comment("The Foreign key to the User how added the feedback")]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

    }
}
