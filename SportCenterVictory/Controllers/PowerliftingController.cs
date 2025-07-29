namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;

    public class PowerliftingController : BaseController
    {
        private readonly IMembershipService membershipService;
        private readonly ITrainerService trainerService;
        private readonly IEventService eventService;


        public PowerliftingController(IMembershipService membershipService, ITrainerService trainerService, IEventService eventService)
        {
            this.membershipService = membershipService;
            this.trainerService = trainerService;
            this.eventService = eventService;
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

            if (eventViewModels == null || !eventViewModels.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.EventsNotFound, "Powerlifting"));
            }

            return View(eventViewModels);

        }
    }
}
