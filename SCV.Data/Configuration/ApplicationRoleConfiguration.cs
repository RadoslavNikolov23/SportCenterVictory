namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SCV.Data.Models;
    using SCV.GlCommon;

    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> entity)
        {
            //For deletion, because their are seeded dynamically to the database

            //entity.HasData(
            //    new ApplicationRole
            //    {
            //        Id = Guid.Parse("8add11c7-0c60-4776-9ad2-b598fa0f05ae"),
            //        Name = RoleConstants.Admin,
            //        NormalizedName = RoleConstants.Admin.ToUpperInvariant()
            //    },
            //    new ApplicationRole
            //    {
            //        Id = Guid.Parse("8d28163a-03ae-4e27-bc00-31d529cd6b52"),
            //        Name = RoleConstants.Manager,
            //        NormalizedName = RoleConstants.Manager.ToUpperInvariant()
            //    },
            //    new ApplicationRole
            //    {
            //        Id = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //        Name = RoleConstants.Trainer,
            //        NormalizedName = RoleConstants.Trainer.ToUpperInvariant()
            //    },
            //    new ApplicationRole
            //    {
            //        Id = Guid.Parse("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"),
            //        Name = RoleConstants.User,
            //        NormalizedName = RoleConstants.User.ToUpperInvariant()
            //    });
        }
    }
}
