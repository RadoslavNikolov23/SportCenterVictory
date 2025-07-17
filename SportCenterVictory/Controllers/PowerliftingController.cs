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
        public IActionResult PowerliftingZone()
        {
            return View();
        }

        public async Task<IActionResult> PowerliftingMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSport(SportType.Powerlifting);

            return View(membershipsVM);
        }

        public async Task<IActionResult> PowerliftingCoaches()
        {
            IEnumerable<TrainerViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialties(SportType.Powerlifting);

            foreach (TrainerViewModel trainer in trainerViewModels)
            {
                trainer.MembershipsByTrainer = await this.membershipService
                                .GetAllMembershipForTrainer(trainer.Id);
            }

            return View(trainerViewModels);

        }

        public async Task<IActionResult> PowerliftingEvents()
        {
            IEnumerable<EventViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventType(SportType.Powerlifting);

            return View(eventViewModels);

        }
    }
}
