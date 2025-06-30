namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;
    using SVC.Data.Models;

    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> entity)
        {
            //entity.HasKey(ex => ex.Id);

            //entity.Property(ex => ex.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //entity.Property(ex => ex.MuscleGroup)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //entity.Property(ex => ex.Description)
            //    .HasMaxLength(1000);

            //entity.Property(ex => ex.ImageUrl)
            //    .HasMaxLength(300);


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
