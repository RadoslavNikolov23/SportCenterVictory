namespace SCV.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> entity)
        {
            //entity.HasData(
            //    new IdentityRole
            //    {
            //        Id = "role-admin",
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new IdentityRole
            //    {
            //        Id = "role-manager",
            //        Name = "Manager",
            //        NormalizedName = "MANAGER"
            //    },
            //    new IdentityRole
            //    {
            //        Id = "role-trainer",
            //        Name = "Trainer",
            //        NormalizedName = "TRAINER"
            //    },
            //    new IdentityRole
            //    {
            //        Id = "role-user",
            //        Name = "User",
            //        NormalizedName = "USER"
            //    });
        }
    }
}
