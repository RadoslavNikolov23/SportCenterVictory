namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstantsCrossfit.CrossfitWorkoutOfTheDayConstraints;

    public class CrossfitWorkoutOfTheDayConfiguration : IEntityTypeConfiguration<CrossfitWorkoutOfTheDay>
    {
        public void Configure(EntityTypeBuilder<CrossfitWorkoutOfTheDay> entity)
        {
            entity
                 .HasKey(wod => wod.Id);

            entity
                .Property(wod => wod.Name)
                .IsRequired()
                .HasMaxLength(WODNameMaxLength);

            entity
                .Property(wod => wod.WorkoutDate)
                .IsRequired();

            entity
                .Property(wod => wod.DescriptionPlain)
                .IsRequired()
                .HasMaxLength(WODDescriptionPlainMaxLength);

            entity
                .Property(wod => wod.DescriptionHTML)
                .IsRequired()
                .HasMaxLength(WODDescriptionHTMLMaxLength);

            //entity.HasData(SeedFromJson<CrossfitWorkoutOfTheDay>(Path.Combine("..", "SeedFiles", "CrossFitWods", "crossfitWodSeed.json")));
        }
    }
}
