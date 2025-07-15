namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.FitnessVM;

    public class PowerliftingController : Controller
    {
        public readonly IMembershipService membershipService;

        public PowerliftingController(IMembershipService membershipService)
        {
            this.membershipService = membershipService;
        }
        public IActionResult PowerliftingZone()
        {
            return View();
        }

        public async Task<IActionResult> CrossFitMembership()
        {
            IEnumerable<MembershipDetailViewModel> membershipsVM = await this.membershipService
                                                .GetAllMembershipPerSport(SportType.Powerlifting);

            return View(membershipsVM);
        }
    }
}
