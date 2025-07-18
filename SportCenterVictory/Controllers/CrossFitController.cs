namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.CrossfitVM;

    public class CrossFitController : Controller
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
        public IActionResult CrossFitArena()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CrossFitMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSportAsync(SportType.CrossFit);

            return View(membershipsVM);
        }

        [HttpGet]
        public async Task<IActionResult> CrossFitCoaches()
        {
            IEnumerable<TrainerDetailViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialtiesAsync(SportType.CrossFit);

            foreach (TrainerDetailViewModel trainer in trainerViewModels)
            {
                trainer.MembershipsByTrainer = await this.membershipService
                                .GetAllMembershipForTrainerAsync(trainer.Id);
            }

            return View(trainerViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> CrossFitEvents()
        {
            IEnumerable<EventDetailViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventTypeAsync(SportType.CrossFit);

            return View(eventViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> CrossFitClasses()
        {
            //TODO: Make a View!!!

            IEnumerable<CrossfitClassDetailViewModel> crossfitClassDetailVM = await this.crossfitClassService
                                    .GetAllCrossfitClassesAsync();

            return View(crossfitClassDetailVM);

        }

        [HttpGet]
        public async Task<IActionResult> CrossFitWOD()
        {
            //TODO: Make a View!!!

            CrossfitWODViewModel? crossfitWODViewModel = await this.crossfitWODService
                                        .GetLatestCrossfitWODAsync();

            if(crossfitWODViewModel == null)
            {
                //TODO: Redirect this to a error page
               return NotFound();
            }

            return View(crossfitWODViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> CrossFitWODList()
        {
            IEnumerable<CrossfitWODViewModel> allCrossfitWODViewModels = await this.crossfitWODService
                                            .GetAllCrossfitWODAsync();

            return Json(allCrossfitWODViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> CrossFitWODById(int id)
        {
            CrossfitWODViewModel? crossfitWODViewModel = await this.crossfitWODService
                                .GetCrossfitWODByIdAsync(id);
            if(crossfitWODViewModel == null)
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
