namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.EventServices.Contracts;
    using SCV.Services.Core.FitnessServices.Contracts;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.FitnessVM;
    using SCV.Web.ViewModels.TrainerVM;

    public class FitnessController : BaseController<FitnessController>
    {
        private readonly IExerciseService exerciseService;
        private readonly IWorkoutPlanService workoutPlanService;
        private readonly ITrainerService trainerService;
        private readonly ITrainerUserService trainerUserService;
        private readonly IEventService eventService;
        private readonly IEventUserService eventUserService;
        private readonly IMembershipService membershipService;
        private readonly IMembershipUserService membershipUserService;

        public FitnessController(IExerciseService exerciseService, IMembershipService membershipService, ITrainerService trainerService, IEventService eventService, IWorkoutPlanService workoutPlanService, IEventUserService eventUserService, IMembershipUserService membershipUserService, ITrainerUserService trainerUserService, ILogger<FitnessController> logger) : base(logger)
        {
            this.exerciseService = exerciseService;
            this.workoutPlanService = workoutPlanService;
            this.trainerService = trainerService;
            this.trainerUserService = trainerUserService;
            this.eventService = eventService;
            this.eventUserService = eventUserService;
            this.membershipService = membershipService;
            this.membershipUserService = membershipUserService;
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

            if (this.IsUserAuthenticated())
            {
                foreach (MembershipDetailViewModel membershipDetailVM in membershipsVM)
                {
                    membershipDetailVM.IsPurchasedMembership = await this.membershipUserService
                        .IsUserAddedToMembershipList(membershipDetailVM.Id, this.GetUserId());

                    membershipDetailVM.CanBeRemoved = await this.membershipUserService
                             .CanUserRemovedIt(membershipDetailVM.Id, this.GetUserId());

                    membershipDetailVM.IsExpired = await this.membershipUserService
                        .IsExpired(membershipDetailVM.Id, this.GetUserId());
                }
            }

            if (membershipsVM == null || !membershipsVM.Any())
            {
                this.logger.LogWarning(string.Format(ErrorMessages.MembershipsNotFound, "the Fitness"));
                return this.NotFoundWithMessage(string.Format(ErrorMessages.MembershipsNotFound, "the Fitness"));
            }

            return View(membershipsVM);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FitnessTrainer()
        {
            IEnumerable<TrainerDetailViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialtiesAsync(SportType.Fitness);

            if (this.IsUserAuthenticated())
            {
                foreach (TrainerDetailViewModel trainerDetailVM in trainerViewModels)
                {
                    trainerDetailVM.IsAddedToFavorites = await this.trainerUserService
                        .IsTrainerAddedToUserList(trainerDetailVM.Id, this.GetUserId());
                }
            }

            if (trainerViewModels == null || !trainerViewModels.Any())
            {
                this.logger.LogWarning(string.Format(ErrorMessages.TrainersNotFound, "the Fitness"));
                return this.NotFoundWithMessage(string.Format(ErrorMessages.TrainersNotFound, "the Fitness"));

            }

            return View(trainerViewModels);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FitnessEvents()
        {
            IEnumerable<EventDetailViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventTypeAsync(SportType.Fitness);

            if (this.IsUserAuthenticated())
            {
                foreach (EventDetailViewModel eventDetailVM in eventViewModels)
                {
                    eventDetailVM.IsUserJoined = await this.eventUserService
                        .IsUserAddedToEventList(eventDetailVM.Id, this.GetUserId());
                }
            }

            if (eventViewModels == null || !eventViewModels.Any())
            {
                this.logger.LogWarning(string.Format(ErrorMessages.EventsNotFound, "the Fitness"));
                return this.NotFoundWithMessage(string.Format(ErrorMessages.EventsNotFound, "the Fitness"));
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
                this.logger.LogWarning(string.Format(ErrorMessages.WorkoutPlansNotFound, "the Fitness"));
                return this.NotFoundWithMessage(string.Format(ErrorMessages.WorkoutPlansNotFound, "the Fitness"));
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
