namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;

    public class PowerliftingController : Controller
    {
        public readonly IMembershipService membershipService;
        public readonly ITrainerService trainerService;
        public readonly IEventService eventService;


        public PowerliftingController(IMembershipService membershipService, ITrainerService trainerService, IEventService eventService)
        {
            this.membershipService = membershipService;
            this.trainerService = trainerService;
            this.eventService = eventService;
        }

        [HttpGet]
        public IActionResult PowerliftingZone()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PowerliftingMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSportAsync(SportType.Powerlifting);

            return View(membershipsVM);
        }

        [HttpGet]
        public async Task<IActionResult> PowerliftingCoaches()
        {
            IEnumerable<TrainerDetailViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialtiesAsync(SportType.Powerlifting);

            foreach (TrainerDetailViewModel trainer in trainerViewModels)
            {
                trainer.MembershipsByTrainer = await this.membershipService
                                .GetAllMembershipForTrainerAsync(trainer.Id);
            }

            return View(trainerViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> PowerliftingEvents()
        {
            IEnumerable<EventDetailViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventTypeAsync(SportType.Powerlifting);

            return View(eventViewModels);

        }
    }
}
