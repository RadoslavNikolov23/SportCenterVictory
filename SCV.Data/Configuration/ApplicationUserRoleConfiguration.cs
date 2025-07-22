namespace SCV.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> entity)
        {
            //entity.HasData(

            //          // Admin
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("8add11c7-0c60-4776-9ad2-b598fa0f05ae"),
            //              UserId = Guid.Parse("28fe258e-8826-4721-abea-f93ce8d1931a")
            //          },

            //          // Manager
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("8d28163a-03ae-4e27-bc00-31d529cd6b52"),
            //              UserId = Guid.Parse("1293b05f-fc49-49d4-8677-9f01f1274b83")
            //          },

            //          // Trainer
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //              UserId = Guid.Parse("ba5666bf-9f1f-4513-92d3-23974d9f687f")
            //          },
            //          // Trainer    
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //              UserId = Guid.Parse("bc4d02a0-44d0-459a-a7e6-04831e417e42")
            //          },

            //          // Trainer  
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //              UserId = Guid.Parse("a42e9995-8da2-4a1a-95a0-653809d0feb3")
            //          },

            //          // Trainer  
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //              UserId = Guid.Parse("c3867b78-36a0-44b5-9800-f359a28d2965")
            //          },

            //          // Trainer  
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //              UserId = Guid.Parse("6bdd6544-e5bb-4490-b980-022aad36802a")
            //          },

            //          // Trainer  
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //              UserId = Guid.Parse("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd")
            //          },
            //          // Trainer
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //              UserId = Guid.Parse("bc52f7d1-319c-4e02-bc81-9a2b1afdd438")
            //          },

            //          // Trainer  
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("e850a970-b0cd-40a1-ad09-4903d92d4d62"),
            //              UserId = Guid.Parse("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c")
            //          },

            //          // User
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"),
            //              UserId = Guid.Parse("16eaaf0f-2efc-4509-8cbe-c8792d187455")
            //          },

            //          // User
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"),
            //              UserId = Guid.Parse("c3777e33-e646-48a2-8e00-03058aa6e054")
            //          },

            //          // User
            //          new IdentityUserRole<Guid>
            //          {
            //              RoleId = Guid.Parse("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"),
            //              UserId = Guid.Parse("d4fd993d-23fd-4832-9d51-d85a16efa5a8")
            //          });
        }
    }
}
