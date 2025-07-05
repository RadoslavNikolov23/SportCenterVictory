namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SCV.Data.Models;
    using static SCV.Data.Common.EntityConstantsTrainer;

    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> entity)
        {
            entity
                .HasKey(t => t.Id);

            entity
                .Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(FirstNameMaxLength);

            entity
                .Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(LastNameMaxLength);

            entity
                .Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(EmailMaxLength);

            entity
                .Property(t => t.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(PhoneNumberMaxLength);

            entity
                .Property(t => t.Bio)
                .IsRequired()
                .HasMaxLength(BioMaxLength);

            entity
                .Property(t => t.TrainerSpecialty)
                .IsRequired();

            entity
                .Property(t => t.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(t => t.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(t => t.IsDeleted==false);


            //// Optional: Seed example trainer
            //entity.HasData(new Trainer
            //{
            //    Id = 1,
            //    FullName = "John Smith",
            //    Bio = "Expert in CrossFit and power training.",
            //    Specialty = "CrossFit",
            //    ImageUrl = "/images/trainers/john-smith.jpg"
            //});
        }
    }
}
