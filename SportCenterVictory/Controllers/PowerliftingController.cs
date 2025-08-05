namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.EventServices.Contracts;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.TrainerVM;

    public class PowerliftingController : BaseController
    {
        private readonly IMembershipService membershipService;
        private readonly ITrainerService trainerService;
        private readonly IEventService eventService;
        private readonly IEventUserService eventUserService;
        private readonly IMembershipUserService membershipUserService;
        private readonly ITrainerUserService trainerUserService;

        public PowerliftingController(IMembershipService membershipService, ITrainerService trainerService, IEventService eventService, IEventUserService eventUserService, IMembershipUserService membershipUserService, ITrainerUserService trainerUserService)
        {
            this.membershipService = membershipService;
            this.trainerService = trainerService;
            this.eventService = eventService;
            this.eventUserService = eventUserService;
            this.membershipUserService = membershipUserService;
            this.trainerUserService = trainerUserService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult PowerliftingZone()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PowerliftingMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSportAsync(SportType.Powerlifting);

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
                return NotFoundWithMessage(string.Format(ErrorMessages.MembershipsNotFound, "Powerlifting"));
            }

            return View(membershipsVM);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PowerliftingCoaches()
        {
            IEnumerable<TrainerDetailViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialtiesAsync(SportType.Powerlifting);

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
                return NotFoundWithMessage(string.Format(ErrorMessages.TrainersNotFound, "Powerlifting"));

            }

            return View(trainerViewModels);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PowerliftingEvents()
        {
            IEnumerable<EventDetailViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventTypeAsync(SportType.Powerlifting);

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
                return NotFoundWithMessage(string.Format(ErrorMessages.EventsNotFound, "Powerlifting"));
            }

            return View(eventViewModels);

        }
    }
}
