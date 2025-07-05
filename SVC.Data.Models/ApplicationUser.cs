namespace SVC.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationUser:IdentityUser
    {
        [Comment("Full name of the user")]
        public string FullName { get; set; } = null!;

        [Comment("The date the user is register On the site")]
        public DateTime RegisteredOn { get; set; }

        [Comment("Collection of orders for the user")]
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
