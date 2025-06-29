namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SVC.Data.Models;

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            entity.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(300);

            entity.Property(e => e.StartDate)
                .IsRequired();

            entity.HasData(new Event
            {
                Id = 1,
                Title = "CrossFit Regional Challenge",
                Description = "A local competition for intermediate-level CrossFitters.",
                Category = "CrossFit",
                StartDate = new DateTime(2025, 7, 20),
                Location = "Ruse Sports Arena",
                ImageUrl = "/images/events/crossfit-challenge.jpg"
            });
        }
    }
}
