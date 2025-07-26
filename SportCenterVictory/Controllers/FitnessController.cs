namespace SportCenterVictory.Controllers
{
    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.FitnessVM;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    public class FitnessController : BaseController
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
        [AllowAnonymous]
        public IActionResult FitnessCenter()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Exercises(int page = 1, int pageSize = 20, string? query = null)
        {
            IEnumerable<ExercisesDetailViewModel> exercises = await this.exerciseService
                                                    .GetExercisesPageAsync(page, pageSize, query);

            if (exercises == null || !exercises.Any())
            {
                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_ExercisePartial", new List<ExercisesDetailViewModel>());
                }

                ViewBag.Message = ErrorMessages.ExercisesNotFound;
                return View(new List<ExercisesDetailViewModel>());
            }

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ExercisePartial", exercises);
            }

            return View(exercises);
        }

        [HttpGet]
        public async Task<IActionResult> FitnessMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSportAsync(SportType.Fitness);

            if (membershipsVM == null || !membershipsVM.Any())
            {
                return NotFound(string.Format(ErrorMessages.MembershipsNotFound, "the Fitness"));
            }

            return View(membershipsVM);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FitnessTrainer()
        {
            IEnumerable<TrainerDetailViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialtiesAsync(SportType.Fitness);

            if (trainerViewModels == null || !trainerViewModels.Any())
            {
                return NotFound(string.Format(ErrorMessages.TrainersNotFound, "the Fitness"));

            }

            foreach (TrainerDetailViewModel trainer in trainerViewModels)
            {
                trainer.MembershipsByTrainer = await this.membershipService
                                .GetAllMembershipForTrainerAsync(trainer.Id.ToString());
            }

            return View(trainerViewModels);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FitnessEvents()
        {
            IEnumerable<EventDetailViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventTypeAsync(SportType.Fitness);

            if (eventViewModels == null || !eventViewModels.Any())
            {
                return NotFound(string.Format(ErrorMessages.EventsNotFound, "the Fitness"));

            }

            return View(eventViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> WorkoutPlans()
        {
            IEnumerable<WorkoutPlanDetailViewModel> workoutPlanDetailVM = await this.workoutPlanService
                                    .GetAllWorkoutPlansBySportTypeAsync(SportType.Fitness);

            if (workoutPlanDetailVM == null || !workoutPlanDetailVM.Any())
            {
                return NotFound(string.Format(ErrorMessages.WorkoutPlansNotFound, "the Fitness"));

            }

            return View(workoutPlanDetailVM);

        }

        [HttpGet]
        public async Task<IActionResult> ExerciseDetails(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return PartialView("_ExerciseNotFoundPopupPartial");
            }

            ExercisesDetailViewModel? exerciseVM = await exerciseService
                                                    .GetExerciseByIdAsync(id);

            if (exerciseVM == null)
            {
                return PartialView("_ExerciseNotFoundPopupPartial");

            }

            return PartialView("_ExercisePopupPartial", exerciseVM);
        }
    }
}
