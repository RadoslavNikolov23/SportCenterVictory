namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SVC.Data.Models;
    using static SVC.Data.Common.EntityConstantsCrossfit.CrossfitClassConstraints;

    public class CrossfitClassConfiguration : IEntityTypeConfiguration<CrossfitClass>
    {
        public void Configure(EntityTypeBuilder<CrossfitClass> entity)
        {
            entity
                .HasKey(cc => cc.Id);

            entity
                .Property(cc => cc.Name)
                .IsRequired()
                .HasMaxLength(ClassNameMaxLength);

            entity
                .Property(cc => cc.Description)
                .IsRequired()
                .HasMaxLength(ClassDescriptionMaxLength);

            entity
                .Property(cc => cc.StartTime)
                .IsRequired();

            entity
                .Property(cc => cc.TrainerName)
                .IsRequired()
                .HasMaxLength(TrainerNameMaxLength);

            entity
                .Property(cc => cc.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            entity
                .HasQueryFilter(cc => cc.IsActive==true);

            //entity
            //    .HasData();


        }
    }
}
