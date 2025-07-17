namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.GlCommon.ModelConstants.EntityConstantsTrainerUser;

    public class TrainerUserConfiguration : IEntityTypeConfiguration<TrainerUser>
    {
        public void Configure(EntityTypeBuilder<TrainerUser> entity)
        {
           entity
                .HasKey(tu => new { tu.ApplicationUserId, tu.TrainerId });

            entity
                .HasOne(tu => tu.ApplicationUser)
                .WithMany(au=>au.TrainerUsers)
                .HasForeignKey(tu => tu.ApplicationUserId);

            entity
                .HasOne(tu => tu.Trainer)
                .WithMany(t => t.TrainerUsers)
                .HasForeignKey(tu => tu.TrainerId);

            entity
                .HasQueryFilter(t=>t.Trainer.IsDeleted==false);

            entity
                .Property(tu => tu.AdditionalInformation)
                .HasMaxLength(AdditionalInformationMaxLength)
                .IsRequired(false);
        }
    }
}
