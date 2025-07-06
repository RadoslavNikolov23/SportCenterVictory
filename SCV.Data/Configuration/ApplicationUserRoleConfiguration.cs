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
            //          });
        }
    }
}
