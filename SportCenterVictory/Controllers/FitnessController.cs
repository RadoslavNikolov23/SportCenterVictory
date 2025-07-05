namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.Services.Core;
    using SCV.Web.ViewModels.FitnessVM;

    public class FitnessController : Controller
    {
        public IActionResult FitnessCenter()
        {
            return View();
        }

        public IActionResult Exercises()
        {
            //var jsonPath = Path.Combine(_webHostEnvironment.WebRootPath, "data", "exercises.json");
            //var exercises = JsonConvert.DeserializeObject<List<Exercise>>(System.IO.File.ReadAllText(jsonPath));
            //return View(exercises);

            FitnessService fitnessService = new FitnessService();

            IEnumerable<ExercisesViewModel>? exercises = fitnessService.GetAllExercises();
            
            //if (string.IsNullOrEmpty(exercises))
            //{
            //    return NotFound("No exercises found.");
            //}

            //ViewBag.Message = exercises;

            return View(exercises);
        }
    }
}
