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
            //              RoleId = "role-admin", // must match Admin Role ID
            //              UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" // must match seeded user
            //          });
        }
    }
}
