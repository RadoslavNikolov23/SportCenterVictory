namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using SCV.Data.Models;

    public class TrainerUserConfiguration : IEntityTypeConfiguration<TrainerUser>
    {
        public void Configure(EntityTypeBuilder<TrainerUser> entity)
        {
            entity
                 .HasKey(tu => new { tu.ApplicationUserId, tu.TrainerId });

            entity
                .Property(tu => tu.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasOne(tu => tu.ApplicationUser)
                .WithMany(au => au.TrainerUsers)
                .HasForeignKey(tu => tu.ApplicationUserId);

            entity
                .HasOne(tu => tu.Trainer)
                .WithMany(t => t.TrainerUsers)
                .HasForeignKey(tu => tu.TrainerId);

            entity
                .HasQueryFilter(tu => tu.IsDeleted == false 
                                   && tu.Trainer.IsDeleted == false);
        }
    }
}
