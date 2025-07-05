namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstantsExercise;

    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
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

            /*----------------------------------------------------------------------------
            //--!!--------The seed for the exercises is done in the exercises.json file--------!!--------
            entity.HasData(exercisesSeed());
            */


        }

        private Exercise[]? exercisesSeed()
        {
            string filePath = Path
                            .Combine(AppContext.BaseDirectory, "wwwroot", "data", "allExercisesSeed.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed JSON file not found", filePath);
            }

            string jsonFile = File
                                .ReadAllText(filePath);


            Exercise[]? exercisesList = JsonConvert
                                             .DeserializeObject<Exercise[]>(jsonFile);

            return exercisesList;
   

        }
    }
}
