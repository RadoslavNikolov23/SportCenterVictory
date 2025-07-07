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
            // Admin User
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
                RegisteredOn = DateTime.UtcNow.Date
            };

            // Manager User
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
                RegisteredOn = DateTime.UtcNow.Date
            };

            // Trainers Users
            ApplicationUser defaultUserViktorNachev = new ApplicationUser
            {
                Id = "trainer-user-id-0003",
                UserName = "viktornachev@sportcentervictory.com",
                NormalizedUserName = "VIKTORNACHEV@SPORTCENTERVICTORY.COM",
                Email = "viktornachev@sportcentervictory.com",
                NormalizedEmail = "VIKTORNACHEV@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Viktor Nachev",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserSofiaLateva = new ApplicationUser
            {
                Id = "trainer-user-id-0004",
                UserName = "sofiazlateva@sportcentervictory.com",
                NormalizedUserName = "SOFIAZLATEVA@SPORTCENTERVICTORY.COM",
                Email = "sofiazlateva@sportcentervictory.com",
                NormalizedEmail = "SOFIAZLATEVA@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Sofia Zlateva",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserDesislavIliev = new ApplicationUser
            {
                Id = "trainer-user-id-0005",
                UserName = "desislaviliev@sportcentervictory.com",
                NormalizedUserName = "DESISLAVILIEV@SPORTCENTERVICTORY.COM",
                Email = "desislaviliev@sportcentervictory.com",
                NormalizedEmail = "DESISLAVILIEV@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Desislav Iliev",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserIvanDimitrov = new ApplicationUser
            {
                Id = "trainer-user-id-0006",
                UserName = "ivandimitrov@sportcentervictory.com",
                NormalizedUserName = "IVANDIMITROV@SPORTCENTERVICTORY.COM",
                Email = "ivandimitrov@sportcentervictory.com",
                NormalizedEmail = "IVANDIMITROV@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Ivan Dimitrov",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserMayaIvanova = new ApplicationUser
            {
                Id = "trainer-user-id-0007",
                UserName = "mayaivanova@sportcentervictory.com",
                NormalizedUserName = "MAYAIVANOVA@SPORTCENTERVICTORY.COM",
                Email = "mayaivanova@sportcentervictory.com",
                NormalizedEmail = "MAYAIVANOVA@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Maya Ivanova",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserGeorgiKolev = new ApplicationUser
            {
                Id = "trainer-user-id-0008",
                UserName = "georgikolev@sportcentervictory.com",
                NormalizedUserName = "GEORGIKOLEV@SPORTCENTERVICTORY.COM",
                Email = "georgikolev@sportcentervictory.com",
                NormalizedEmail = "GEORGIKOLEV@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Georgi Kolev",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserKristinaDimitrova = new ApplicationUser
            {
                Id = "trainer-user-id-0009",
                UserName = "kristinadimitrova@sportcentervictory.com",
                NormalizedUserName = "KRISTINADIMITROVA@SPORTCENTERVICTORY.COM",
                Email = "kristinadimitrova@sportcentervictory.com",
                NormalizedEmail = "KRISTINADIMITROVA@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Kristina Dimitrova",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserStefanTodorov = new ApplicationUser
            {
                Id = "trainer-user-id-0010",
                UserName = "stefantodorov@sportcentervictory.com",
                NormalizedUserName = "STEFANTODOROV@SPORTCENTERVICTORY.COM",
                Email = "stefantodorov@sportcentervictory.com",
                NormalizedEmail = "STEFANTODOROV@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Stefan Todorov",
                RegisteredOn = DateTime.UtcNow.Date

            };

            // Regular Users
            ApplicationUser defaultUserVictoriaDimitrova = new ApplicationUser
            {
                Id = "regular-user-id-0011",
                UserName = "victoriadimitrova@sportcentervictory.com",
                NormalizedUserName = "VICTORIADIMITROVA@SPORTCENTERVICTORY.COM",
                Email = "victoriadimitrova@sportcentervictory.com",
                NormalizedEmail = "VICTORIADIMITROVA@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Victoria Dimitrova",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserIvanPetrov = new ApplicationUser
            {
                Id = "regular-user-id-0012",
                UserName = "ivanpetrov@sportcentervictory.com",
                NormalizedUserName = "IVANPETROV@SPORTCENTERVICTORY.COM",
                Email = "ivanpetrov@sportcentervictory.com",
                NormalizedEmail = "IVANPETROV@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Ivan Petrov",
                RegisteredOn = DateTime.UtcNow.Date
            };

            ApplicationUser defaultUserMariaStefanova = new ApplicationUser
            {
                Id = "regular-user-id-0013",
                UserName = "mariastefanova@sportcentervictory.com",
                NormalizedUserName = "MARIASTEFANOVA@SPORTCENTERVICTORY.COM",
                Email = "mariastefanova@sportcentervictory.com",
                NormalizedEmail = "MARIASTEFANOVA@SPORTCENTERVICTORY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Maria Stefanova",
                RegisteredOn = DateTime.UtcNow.Date
            };

            // Hashing Passwords Generation
            defaultUserAdmin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserAdmin, "Admin123!");
            defaultUserManager.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserManager, "Rado123!");

            defaultUserViktorNachev.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserViktorNachev, "Victor123!");
            defaultUserSofiaLateva.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserSofiaLateva, "Sofia123!");
            defaultUserDesislavIliev.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserDesislavIliev, "Desislav123!");
            defaultUserIvanDimitrov.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserIvanDimitrov, "Ivan123!");
            defaultUserMayaIvanova.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserMayaIvanova, "Maya123!");
            defaultUserGeorgiKolev.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserGeorgiKolev, "Georgi123!");
            defaultUserKristinaDimitrova.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserKristinaDimitrova, "Kristina123!");
            defaultUserStefanTodorov.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserStefanTodorov, "Stefan123!");

            defaultUserVictoriaDimitrova.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserVictoriaDimitrova, "Victoria123!");
            defaultUserIvanPetrov.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserIvanPetrov, "Ivan123!");
            defaultUserMariaStefanova.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(defaultUserMariaStefanova, "Maria123!");


            // Adding to the collection
            applicationUsers.Add(defaultUserAdmin);
            applicationUsers.Add(defaultUserManager);

            applicationUsers.Add(defaultUserViktorNachev);
            applicationUsers.Add(defaultUserSofiaLateva);
            applicationUsers.Add(defaultUserDesislavIliev);
            applicationUsers.Add(defaultUserIvanDimitrov);
            applicationUsers.Add(defaultUserMayaIvanova);
            applicationUsers.Add(defaultUserGeorgiKolev);
            applicationUsers.Add(defaultUserKristinaDimitrova);
            applicationUsers.Add(defaultUserStefanTodorov);

            applicationUsers.Add(defaultUserVictoriaDimitrova);
            applicationUsers.Add(defaultUserIvanPetrov);
            applicationUsers.Add(defaultUserMariaStefanova);

            return applicationUsers;
        }
    }
}
