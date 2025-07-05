namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SCV.Data.Models;
    using static SCV.Data.Common.EntityConstantsEvent;

    public class EventConfiguration : IEntityTypeConfiguration<Event>
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

            //entity.HasData(new Event
            //{
            //    Id = 1,
            //    Title = "CrossFit Regional Challenge",
            //    Description = "A local competition for intermediate-level CrossFitters.",
            //    Category = "CrossFit",
            //    StartDate = new DateTime(2025, 7, 20),
            //    Location = "Ruse Sports Arena",
            //    ImageUrl = "/images/events/crossfit-challenge.jpg"
            //});
        }
    }
}
