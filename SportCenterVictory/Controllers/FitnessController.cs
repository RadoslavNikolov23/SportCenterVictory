namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SVC.Services.Core;

    public class FitnessController : Controller
    {
        public IActionResult FitnessCenter()
        {
            return View();
        }

        public IActionResult Exercises()
        {

            FitnessService fitnessService = new FitnessService();

            string exercises = fitnessService.GetAllExercises();
            if (string.IsNullOrEmpty(exercises))
            {
                return NotFound("No exercises found.");
            }

            //ViewBag.Message = exercises;

            return View();
        }
    }
}
