namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.CrossfitVM;
    using SCV.Web.ViewModels.TrainerVM;

    public class CrossFitController : BaseController
    {
        private readonly IMembershipService membershipService;
        private readonly ITrainerService trainerService;
        private readonly IEventService eventService;
        private readonly ICrossfitClassService crossfitClassService;
        private readonly ICrossfitWODService crossfitWODService;
        private readonly IEventUserService eventUserService;
        private readonly IMembershipUserService membershipUserService;
        private readonly ICrossfitClassUserService crossfitClassUserService;
        private readonly ITrainerUserService trainerUserService;

        public CrossFitController(IMembershipService membershipService, ITrainerService trainerService, IEventService eventService, ICrossfitClassService crossfitClassService, ICrossfitWODService crossfitWODService, IEventUserService eventUserService, IMembershipUserService membershipUserService, ICrossfitClassUserService crossfitClassUserService, ITrainerUserService trainerUserService)
        {
            this.membershipService = membershipService;
            this.trainerService = trainerService;
            this.eventService = eventService;
            this.crossfitClassService = crossfitClassService;
            this.crossfitWODService = crossfitWODService;
            this.eventUserService = eventUserService;
            this.membershipUserService = membershipUserService;
            this.crossfitClassUserService = crossfitClassUserService;
            this.trainerUserService = trainerUserService;
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

            if (this.IsUserAuthenticated())
            {
                foreach (MembershipDetailViewModel membershipDetailVM in membershipsVM)
                {
                    membershipDetailVM.IsPurchasedMembership = await this.membershipUserService
                        .IsUserAddedToMembershipList(membershipDetailVM.Id, this.GetUserId());
                }
            }

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
                return NotFoundWithMessage(string.Format(ErrorMessages.TrainersNotFound, "CrossFit"));

            }

            return View(trainerViewModels);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CrossFitEvents()
        {
            IEnumerable<EventDetailViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventTypeAsync(SportType.CrossFit);

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
                return NotFoundWithMessage(string.Format(ErrorMessages.EventsNotFound, "CrossFit"));
            }

            return View(eventViewModels);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CrossFitClasses()
        {
            IEnumerable<CrossfitClassDetailViewModel> allCrossfitClassDetailVM = await this.crossfitClassService
                                    .GetAllCrossfitClassesAsync();

            if (this.IsUserAuthenticated())
            {
                foreach (CrossfitClassDetailViewModel crossfitClassDetailVM in allCrossfitClassDetailVM)
                {
                    crossfitClassDetailVM.IsUserJoined = await this.crossfitClassUserService
                        .IsUserAddedToCrossfitClassList(crossfitClassDetailVM.CrossfitClassId, this.GetUserId());
                }
            }

            if (allCrossfitClassDetailVM == null || !allCrossfitClassDetailVM.Any())
            {
                return NotFoundWithMessage(ErrorMessages.CrossfitClassesNotFound);
            }

            return View(allCrossfitClassDetailVM);

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
        public async Task<IActionResult> CrossFitWODById(string id)
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
