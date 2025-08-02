namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using SCV.Data.Models;

    using static SCV.GlCommon.ModelConstants.EntityConstantsMembership;
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
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType(PriceSqlType);

            entity
                .Property(m => m.DurationText)
                .IsRequired()
                .HasMaxLength(DurationTextMaxLength);

            entity
                .Property(m => m.Duration)
                .IsRequired();
                
            entity
                .Property(m => m.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(e => e.IsDeleted == false);

            entity.HasData(SeedFromJson<Membership>(Path.Combine("..", "SCV.Data", "SeedFiles", "Memberships", "membershipsSeed.json")));

        }
    }
}
