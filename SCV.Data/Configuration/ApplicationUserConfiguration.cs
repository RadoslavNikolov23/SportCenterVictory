namespace SCV.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SCV.Data.Models;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            //entity
            //     .HasData(this.SeedDefaultUser());
        }

        private ApplicationUser SeedDefaultUser()
        {
            PasswordHasher<ApplicationUser> hasherUser = new PasswordHasher<ApplicationUser>();

            ApplicationUser defaultUser = new ApplicationUser
            {
                Id = "admin-user-id-0001",
                UserName = "admin@demo.com",
                NormalizedUserName = "ADMIN@DEMO.COM",
                Email = "admin@demo.com",
                NormalizedEmail = "ADMIN@DEMO.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Admin User",
                RegisteredOn = DateTime.UtcNow,
            };

            defaultUser.PasswordHash = hasherUser.HashPassword(defaultUser, "Admin123");

            return defaultUser;
        }

        
        
    }
}
