namespace SCV.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SCV.Data.Models;

    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> entity)
        {
            entity.HasData(
                new ApplicationRole
                {
                    Id = Guid.Parse("8add11c7-0c60-4776-9ad2-b598fa0f05ae"),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("8d28163a-03ae-4e27-bc00-31d529cd6b52"),
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
                    Name = "Trainer",
                    NormalizedName = "TRAINER"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"),
                    Name = "User",
                    NormalizedName = "USER"
                });
        }
    }
}
