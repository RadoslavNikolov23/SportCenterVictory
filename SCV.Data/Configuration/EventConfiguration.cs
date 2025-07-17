namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.GlCommon.ModelConstants.EntityConstantsEvent;

    public class EventConfiguration : BaseConfiguration, IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            entity
                .Property(e => e.EventType)
                .IsRequired();

            entity
                .Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(e => e.StartDate)
                .IsRequired();

            entity
                .Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(LocationMaxLength);

            entity
                .Property(e => e.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(e => e.IsDeleted==false);

            entity.HasData(SeedFromJson<Event>(Path.Combine("..", "SCV.Data", "SeedFiles", "Events", "eventsSeed.json")));
        }
    }
}
