namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MembershipUserConfiguration : IEntityTypeConfiguration<MembershipUser>
    {
        public void Configure(EntityTypeBuilder<MembershipUser> entity)
        {
            entity
                .HasKey(mu => new { mu.ApplicationUserId, mu.MembershipId });

            entity
                .Property(mu => mu.PurchasedOn)
                .IsRequired();

            entity
                .Property(mu => mu.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(mu => mu.IsDeleted == false);

            entity
                .HasOne(mu => mu.ApplicationUser)
                .WithMany()
                .HasForeignKey(mu => mu.ApplicationUserId);

            entity
                .HasOne(mu => mu.Membership)
                .WithMany(m => m.MembershipUsers)
                .HasForeignKey(mu => mu.MembershipId);

           entity
                .HasQueryFilter(mu => mu.Membership.IsDeleted == false);

        }
    }
}
