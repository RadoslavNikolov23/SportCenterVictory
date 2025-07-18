namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;

    public class CrossFitController : Controller
    {
        public readonly IMembershipService membershipService;
        public readonly ITrainerService trainerService;
        public readonly IEventService eventService;


        public CrossFitController(IMembershipService membershipService, ITrainerService trainerService, IEventService eventService)
        {
            this.membershipService = membershipService;
            this.trainerService = trainerService;
            this.eventService = eventService;
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
    }
}
