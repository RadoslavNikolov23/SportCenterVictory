namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.FitnessVM;

    public class FitnessController : Controller
    {
        public readonly IExerciseService exerciseService;
        public readonly IMembershipService membershipService;
        public readonly ITrainerService trainerService;

        public FitnessController(IExerciseService exerciseService, IMembershipService membershipService, ITrainerService trainerService)
        {
            this.exerciseService = exerciseService;
            this.membershipService = membershipService;
            this.trainerService = trainerService;
        }

        public IActionResult FitnessCenter()
        {
            return View();
        }

        public async Task<IActionResult> Exercises(int page = 1, int pageSize = 20, string? query = null)
        {
            IEnumerable<ExercisesIndexViewModel> exercises = await this.exerciseService
                                                    .GetExercisesPageAsync(page, pageSize, query);

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ExercisePartial", exercises);
            }

           // ViewData["Title"] = "Exercises";
            return View(exercises);
        }

        public async Task<IActionResult> FitnessMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSport(SportType.Fitness);

            return View(membershipsVM);

        }

        public async Task<IActionResult> FitnessTrainer()
        {
            IEnumerable<TrainerViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialties(SportType.Fitness);

            foreach (TrainerViewModel trainer in trainerViewModels)
            {
                trainer.MembershipsByTrainer = await this.membershipService
                                .GetAllMembershipForTrainer(trainer.Id);
            }

            return View(trainerViewModels);

        }
    }
}
