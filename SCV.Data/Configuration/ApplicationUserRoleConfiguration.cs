namespace SCV.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> entity)
        {
            //entity.HasData(
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-admin",
            //              UserId = "admin-user-id-0001"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-manager",
            //              UserId = "manager-user-id-0002"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-trainer",
            //              UserId = "trainer-user-id-0003"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-trainer",
            //              UserId = "trainer-user-id-0004"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-trainer",
            //              UserId = "trainer-user-id-0005"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-trainer",
            //              UserId = "trainer-user-id-0006"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-trainer",
            //              UserId = "trainer-user-id-0007"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-trainer",
            //              UserId = "trainer-user-id-0008"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-trainer",
            //              UserId = "trainer-user-id-0009"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-trainer",
            //              UserId = "trainer-user-id-0010"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-user",
            //              UserId = "regular-user-id-0011"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-user",
            //              UserId = "regular-user-id-0012"
            //          },
            //          new IdentityUserRole<string>
            //          {
            //              RoleId = "role-user",
            //              UserId = "regular-user-id-0013"
            //          });
        }
    }
}
