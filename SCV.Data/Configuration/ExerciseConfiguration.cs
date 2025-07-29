namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using SCV.Data.Models;

    using static SCV.GlCommon.ModelConstants.EntityConstantsExercise;

    public class ExerciseConfiguration : BaseConfiguration, IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Id)
                .HasMaxLength(IdMaxLength);

            entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(e => e.Force)
                .IsRequired(false)
                .HasMaxLength(ForceMaxLength);

            entity
                .Property(e => e.Mechanic)
                .IsRequired(false)
                .HasMaxLength(MechanicMaxLength);

            entity
                .Property(e => e.Equipment)
                .IsRequired(false)
                .HasMaxLength(EquipmentMaxLength);

            entity
                .Property(e => e.PrimaryMuscles)
                .IsRequired()
                .HasMaxLength(PrimaryMusclesMaxLength);

            entity
                .Property(e => e.SecondaryMuscles)
                .IsRequired(false)
                .HasMaxLength(SecondaryMusclesMaxLength);

            entity
                .Property(e => e.Instructions)
                .IsRequired(false)
                .HasMaxLength(InstructionsMaxLength);

            entity
                .Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(CategoryMaxLength);

            entity
                .Property(e => e.ImageUrlOne)
                .IsRequired(false)
                .HasMaxLength(ImageUrlOneMaxLength);

            entity
                .Property(e => e.ImageUrlTwo)
                .IsRequired(false)
                .HasMaxLength(ImageUrlTwoMaxLength);

            entity
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(e => e.IsDeleted==false);

            entity.HasData(SeedFromJson<Exercise>(Path.Combine("..", "SCV.Data", "SeedFiles", "ExercisesAll", "allExercisesSeed.json")));

        }
    }
}
