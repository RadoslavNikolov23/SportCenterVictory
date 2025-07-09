namespace SCV.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> entity)
        {
            entity.HasData(
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-admin",
                          UserId = "28fe258e-8826-4721-abea-f93ce8d1931a"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-manager",
                          UserId = "1293b05f-fc49-49d4-8677-9f01f1274b83"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-trainer",
                          UserId = "ba5666bf-9f1f-4513-92d3-23974d9f687f"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-trainer",
                          UserId = "bc4d02a0-44d0-459a-a7e6-04831e417e42"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-trainer",
                          UserId = "a42e9995-8da2-4a1a-95a0-653809d0feb3"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-trainer",
                          UserId = "c3867b78-36a0-44b5-9800-f359a28d2965"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-trainer",
                          UserId = "6bdd6544-e5bb-4490-b980-022aad36802a"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-trainer",
                          UserId = "bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-trainer",
                          UserId = "bc52f7d1-319c-4e02-bc81-9a2b1afdd438"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-trainer",
                          UserId = "4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-user",
                          UserId = "16eaaf0f-2efc-4509-8cbe-c8792d187455"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-user",
                          UserId = "c3777e33-e646-48a2-8e00-03058aa6e054"
                      },
                      new IdentityUserRole<string>
                      {
                          RoleId = "role-user",
                          UserId = "d4fd993d-23fd-4832-9d51-d85a16efa5a8"
                      });
        }
    }
}
