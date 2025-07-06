namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstantsTrainerUser;

    public class TrainerUserConfiguration : IEntityTypeConfiguration<TrainerUser>
    {
        public void Configure(EntityTypeBuilder<TrainerUser> entity)
        {
           entity
                .HasKey(tu => new { tu.ApplicationUserId, tu.trainerId });

            entity
                .HasOne(tu => tu.ApplicationUser)
                .WithMany()
                .HasForeignKey(tu => tu.ApplicationUserId);

            entity
                .HasOne(tu => tu.Trainer)
                .WithMany(t => t.TrainerUsers)
                .HasForeignKey(tu => tu.trainerId);

            entity
                .HasQueryFilter(t=>t.Trainer.IsDeleted==false);

            entity
                .Property(tu => tu.AdditionalInformation)
                .HasMaxLength(AdditionalInformationMaxLength)
                .IsRequired(false);
        }
    }
}
