namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents user feedback in the system.")]
    public class UserFeedback
    {
        [Comment("Primary key for the UserFeedback Table.")]
        public int Id { get; set; }

        [Comment("The name of the user who provided the feedback.")]
        public string UserName { get; set; } = null!;

        [Comment("The context of the feedback.")]
        public string Feedback { get; set; } = null!;

        [Comment("The Foreing key to the User how added the feedback")]
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; set; }
 
    }
}
