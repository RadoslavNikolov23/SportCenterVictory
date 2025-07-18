namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.FitnessVM;

    public class FitnessController : Controller
    {
        private readonly IExerciseService exerciseService;
        private readonly IMembershipService membershipService;
        private readonly ITrainerService trainerService;
        private readonly IEventService eventService;
        private readonly IWorkoutPlanService workoutPlanService;

        public FitnessController(IExerciseService exerciseService, IMembershipService membershipService, ITrainerService trainerService, IEventService eventService, IWorkoutPlanService workoutPlanService)
        {
            this.exerciseService = exerciseService;
            this.membershipService = membershipService;
            this.trainerService = trainerService;
            this.eventService = eventService;
            this.workoutPlanService = workoutPlanService;
        }

        [HttpGet]
        public IActionResult FitnessCenter()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Exercises(int page = 1, int pageSize = 20, string? query = null)
        {
            IEnumerable<ExercisesDetailViewModel> exercises = await this.exerciseService
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

        [HttpGet]
        public async Task<IActionResult> FitnessMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSportAsync(SportType.Fitness);

            return View(membershipsVM);

        }

        [HttpGet]
        public async Task<IActionResult> FitnessTrainer()
        {
            IEnumerable<TrainerDetailViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialtiesAsync(SportType.Fitness);

            foreach (TrainerDetailViewModel trainer in trainerViewModels)
            {
                trainer.MembershipsByTrainer = await this.membershipService
                                .GetAllMembershipForTrainerAsync(trainer.Id);
            }

            return View(trainerViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> FitnessEvents()
        {
            IEnumerable<EventDetailViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventTypeAsync(SportType.Fitness);

            return View(eventViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> WorkoutPlans()
        {
            IEnumerable<WorkoutPlanDetailViewModel> workoutPlanDetailVM = await this.workoutPlanService
                                    .GetAllWorkoutPlansBySportTypeAsync(SportType.Fitness);

            return View(workoutPlanDetailVM);

        }

        [HttpGet]
        public async Task<IActionResult> ExerciseDetails(string id)
        {
            ExercisesDetailViewModel? exerciseVM = await exerciseService
                                                    .GetExerciseByIdAsync(id);
   
            if (exerciseVM == null)
            {
                //TODO: Some other redirect
                return NotFound();
            }

            return PartialView("_ExercisePopupPartial", exerciseVM);
        }
    }
}
