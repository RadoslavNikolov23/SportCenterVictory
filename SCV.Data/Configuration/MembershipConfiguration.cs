namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstantsMembership;
    using static SCV.GlCommon.ApplicationConstants;

    public class MembershipConfiguration : BaseConfiguration, IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> entity)
        {
            entity
                .HasKey(m => m.Id);

            entity
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(m => m.MembershipType)
                .IsRequired();

            entity
                .Property(m => m.MembershipTier)
                .IsRequired();

            entity
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType(PriceSqlType);

            entity
                .Property(m => m.Duration)
                .IsRequired()
                .HasMaxLength(DurationMaxLength);

            entity
                .Property(m => m.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(e => e.IsDeleted == false);

            entity
                .HasOne(m => m.Trainer)
                .WithMany(t => t.Memberships)
                .HasForeignKey(m => m.TrainerId);

            entity.HasData(SeedFromJson<Membership>(Path.Combine("..", "SCV.Data", "SeedFiles", "Memberships", "membershipsSeed.json")));

        }
    }
}
