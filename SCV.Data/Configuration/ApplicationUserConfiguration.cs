namespace SCV.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> entity)
        {
            //entity
            //     .HasData(this.SeedDefaultUser());
        }

        private IdentityUser SeedDefaultUser()
        {
            PasswordHasher<IdentityUser> hasherUser = new PasswordHasher<IdentityUser>();

            IdentityUser defaultUser = new IdentityUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin",
                NormalizedUserName = "ADMINSVC",
                Email = "admin@sportcentervictory.com",
                NormalizedEmail = "ADMIN@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            defaultUser.PasswordHash = hasherUser.HashPassword(defaultUser, "Admin123");

            return defaultUser;
        }

        
        
    }
}
