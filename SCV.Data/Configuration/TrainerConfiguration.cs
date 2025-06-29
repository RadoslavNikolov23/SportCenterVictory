namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SVC.Data.Models;

    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> entity)
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(t => t.Bio)
                .HasMaxLength(1000);

            entity.Property(t => t.Specialty)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(t => t.ImageUrl)
                .HasMaxLength(300);

            // Optional: Seed example trainer
            entity.HasData(new Trainer
            {
                Id = 1,
                FullName = "John Smith",
                Bio = "Expert in CrossFit and power training.",
                Specialty = "CrossFit",
                ImageUrl = "/images/trainers/john-smith.jpg"
            });
        }
    }
}
