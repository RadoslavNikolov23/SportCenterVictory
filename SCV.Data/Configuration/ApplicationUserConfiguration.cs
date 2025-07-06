namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstantsApplicationUser;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            entity
                .Property(au=> au.FullName)
                .IsRequired()
                .HasMaxLength(FullNameMaxLength);

            entity
                .Property(au => au.RegisteredOn)
                .IsRequired();

            //entity
            //     .HasData(this.SeedDefaultUser());
        }

        private ICollection<ApplicationUser> SeedDefaultUser()
        {
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
;
            ApplicationUser defaultUserAdmin = new ApplicationUser
            {
                Id = "admin-user-id-0001",
                UserName = "admin@sportcentervictory.com",
                NormalizedUserName = "ADMIN@SPORTCENTERVICTORY.COM",
                Email = "admin@sportcentervictory.com",
                NormalizedEmail = "ADMIN@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Admin User - Rado",
                RegisteredOn = DateTime.UtcNow,
            };

            ApplicationUser defaultUserManager = new ApplicationUser
            {
                Id = "manager-user-id-0002",
                UserName = "manager@sportcentervictory.com",
                NormalizedUserName = "MANAGER@SPORTCENTERVICTORY.COM",
                Email = "manager@sportcentervictory.com",
                NormalizedEmail = "MANAGER@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Manager Rado",
                RegisteredOn = DateTime.UtcNow,
            };

            defaultUserAdmin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserAdmin, "Admin123!");
            defaultUserManager.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserManager, "Rado123!");


            applicationUsers.Add(defaultUserAdmin);
            applicationUsers.Add(defaultUserManager);

            return applicationUsers;
        }
    }
}
