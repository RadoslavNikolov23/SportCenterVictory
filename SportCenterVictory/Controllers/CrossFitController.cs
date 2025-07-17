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

        public IActionResult CrossFitArena()
        {
            return View();
        }

        public async Task<IActionResult> CrossFitMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSport(SportType.CrossFit);

            return View(membershipsVM);
        }

        public async Task<IActionResult> CrossFitCoaches()
        {
            IEnumerable<TrainerViewModel> trainerViewModels = await this.trainerService
                                        .GetAllTrainerBySpecialties(SportType.CrossFit);

            foreach (TrainerViewModel trainer in trainerViewModels)
            {
                trainer.MembershipsByTrainer = await this.membershipService
                                .GetAllMembershipForTrainer(trainer.Id);
            }

            return View(trainerViewModels);

        }

        public async Task<IActionResult> CrossFitEvents()
        {
            IEnumerable<EventViewModel> eventViewModels = await this.eventService
                                    .GetAllEventByEventType(SportType.CrossFit);

            return View(eventViewModels);

        }
    }
}
