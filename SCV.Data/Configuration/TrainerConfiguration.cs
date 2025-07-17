namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.GlCommon.ModelConstants.EntityConstantsTrainer;

    public class TrainerConfiguration : BaseConfiguration, IEntityTypeConfiguration<Trainer>
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

            entity
                .HasOne(t => t.ApplicationUser)
                .WithMany(au=>au.Trainers)
                .HasForeignKey(t => t.ApplicationUserId);

            entity.HasData(SeedFromJson<Trainer>(Path.Combine("..", "SCV.Data", "SeedFiles", "Trainers", "trainersSeed.json")));

            // Uncomment the following line if you want to seed additional trainers
            /*
             *   {
    "Id": "ec83a001-55df-45e5-b8c4-91f4d76f9fd0",
    "FirstName": "Maya",
    "LastName": "Ivanova",
    "Email": "maya.ivanova@svc.bg",
    "PhoneNumber": "+359885987654",
    "Bio": "Fitness and bodybuilding expert with over 10 years of personal training experience.",
    "TrainerSpecialty": 1,
    "ImageUrl": "images/Trainers/Crossfit/mayaIvanova.jpg"
  },
            has to be a crossfit not a fitness/bodubuilding trainer!!!!!!
             */
        }
    }
}
