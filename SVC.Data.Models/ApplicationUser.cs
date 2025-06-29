namespace SVC.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; } = null!;

        public DateTime RegisteredOn { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
