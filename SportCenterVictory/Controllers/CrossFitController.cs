namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.CrossfitVM;

    public class CrossFitController : BaseController
    {
        private readonly IMembershipService membershipService;
        private readonly ITrainerService trainerService;
        private readonly IEventService eventService;
        private readonly ICrossfitClassService crossfitClassService;
        private readonly ICrossfitWODService crossfitWODService;

        public CrossFitController(IMembershipService membershipService, ITrainerService trainerService, IEventService eventService, ICrossfitClassService crossfitClassService, ICrossfitWODService crossfitWODService)
        {
            this.membershipService = membershipService;
            this.trainerService = trainerService;
            this.eventService = eventService;
            this.crossfitClassService = crossfitClassService;
            this.crossfitWODService = crossfitWODService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CrossFitArena()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CrossFitMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSportAsync(SportType.CrossFit);

            if (membershipsVM == null || !membershipsVM.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.MembershipsNotFound, "CrossFit"));

            }

            return View(membershipsVM);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CrossFitCoaches()
        {
            IEnumerable<TrainerDetailViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialtiesAsync(SportType.CrossFit);

            if (trainerViewModels == null || !trainerViewModels.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.TrainersNotFound, "CrossFit"));

            }

            foreach (TrainerDetailViewModel trainer in trainerViewModels)
            {
                trainer.MembershipsByTrainer = await this.membershipService
                                .GetAllMembershipForTrainerAsync(trainer.Id);
            }

            return View(trainerViewModels);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CrossFitEvents()
        {
            IEnumerable<EventDetailViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventTypeAsync(SportType.CrossFit);

            if (eventViewModels == null || !eventViewModels.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.EventsNotFound, "CrossFit"));
            }

            return View(eventViewModels);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CrossFitClasses()
        {
            IEnumerable<CrossfitClassDetailViewModel> crossfitClassDetailVM = await this.crossfitClassService
                                    .GetAllCrossfitClassesAsync();

            if(crossfitClassDetailVM == null || !crossfitClassDetailVM.Any())
            {
                return NotFoundWithMessage(ErrorMessages.CrossfitClassesNotFound);
            }

            return View(crossfitClassDetailVM);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CrossFitWOD()
        {
            CrossfitWODViewModel? crossfitWODViewModel = await this.crossfitWODService
                                        .GetLatestCrossfitWODAsync();

            if (crossfitWODViewModel == null)
            {
                return NotFoundWithMessage(ErrorMessages.CrossfitWODNotFound);
            }

            return View(crossfitWODViewModel);

        }

        [AllowAnonymous]
        public async Task<IActionResult> CrossFitWODList()
        {
            IEnumerable<CrossfitWODViewModel> allCrossfitWODViewModels = await this.crossfitWODService
                                            .GetAllCrossfitWODAsync();

            return Json(allCrossfitWODViewModels);
        }

        [AllowAnonymous]
        public async Task<IActionResult> CrossFitWODById(int id)
        {
            CrossfitWODViewModel? crossfitWODViewModel = await this.crossfitWODService
                                .GetCrossfitWODByIdAsync(id);
            if (crossfitWODViewModel == null)
            {
                return NotFound();
            }

            return Json(new
            {
                name = crossfitWODViewModel.Name,
                descriptionHTML = crossfitWODViewModel.DescriptionHTML
            });
        }
    }
}
