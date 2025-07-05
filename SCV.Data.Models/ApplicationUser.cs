namespace SCV.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [Comment("Application user model that extends IdentityUser")]
    public class ApplicationUser:IdentityUser
    {
        [Comment("Full name of the user")]
        public string FullName { get; set; } = null!;

        [Comment("The date the user is register On the site")]
        public DateTime RegisteredOn { get; set; }

        [Comment("Collection of orders for the user")]
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
