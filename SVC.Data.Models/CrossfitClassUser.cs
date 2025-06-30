namespace SVC.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class CrossfitClassUser
    {
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;

        public string CrossfitClassId { get; set; } = null!;

        // Navigation properties
        public CrossfitClass CrossfitClass { get; set; } = null!;

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    }
}
