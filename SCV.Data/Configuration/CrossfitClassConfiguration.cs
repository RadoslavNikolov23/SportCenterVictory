namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstantsCrossfit.CrossfitClassConstraints;

    public class CrossfitClassConfiguration : BaseConfiguration, IEntityTypeConfiguration<CrossfitClass>
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
                .IsRequired()
                .HasMaxLength(ClassStartTimeMaxLength);

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


            entity.HasData(SeedFromJson<CrossfitClass>(Path.Combine("..", "SCV.Data", "SeedFiles", "CrossFitClasses", "crossfitClassesSeed.json")));
        }
    }
}
