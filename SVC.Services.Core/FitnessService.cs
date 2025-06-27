namespace SVC.Services.Core
{
    using Microsoft.AspNetCore.Hosting;
    using Newtonsoft.Json;
    using SVC.Web.ViewModels.FitnessVM;
    using System.Text;

    public class FitnessService
    {
        public string GetAllExercises()
        {
            StringBuilder sb = new StringBuilder();

            // Get the root directory of the application
            string rootPath = Directory.GetCurrentDirectory();

            // Combine it with the relative path to the file inside the wwwroot folder
            string filePath = Path.Combine(rootPath, "wwwroot", "json", "exercises.json");

            // Read the file content
            string jsonFile = System.IO.File.ReadAllText(filePath);


            ExercisesViewModel[]? exercisesList = JsonConvert
                 .DeserializeObject<ExercisesViewModel[]>(jsonFile);


            if (exercisesList==null || exercisesList.Length==0)
            {
                return "No exercises found!";
            }

            foreach (ExercisesViewModel exercise in exercisesList)
            {
                sb.AppendLine($"Exercise: {exercise.Name}, {exercise.Force}, {exercise.Mechanic}, {exercise.Equipment} ");

                foreach (string primaryMusc in exercise.PrimaryMuscles)
                {
                    sb.AppendLine($"Primary muscles {primaryMusc}");
                }

                if(exercise.SecondaryMuscles != null || exercise.SecondaryMuscles!.Count != 0)
                {
                    foreach (string seconMusc in exercise.SecondaryMuscles)
                    {
                        sb.AppendLine($"Secondary muscles {seconMusc}");
                    }
                }



                if (exercise.Instructions != null || exercise.Instructions!.Count != 0)
                {
                    sb.AppendLine($"Instruction: ");

                    foreach (string instruc in exercise.Instructions)
                    {
                        sb.AppendLine($"----- {instruc}");
                    }
                }
                else
                {
                    sb.AppendLine($" No Instruction found!");

                }

                sb.AppendLine($"Category: {exercise.Category}");


                if (exercise.Images != null || exercise.Images!.Count != 0)
                {
                    
                        sb.AppendLine($"Images: {string.Join(",", exercise.Images)}");

                    
                }
                else
                {
                    sb.AppendLine($" No Images found!");

                }

                sb.AppendLine("----------------------------------------");
            }

            sb.AppendLine("End");

            return sb.ToString().TrimEnd();

        }
    }
}
