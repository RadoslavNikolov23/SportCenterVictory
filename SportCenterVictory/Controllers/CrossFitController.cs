namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;

    public class CrossFitController : Controller
    {
        public readonly IMembershipService membershipService;

        public CrossFitController(IMembershipService membershipService)
        {
            this.membershipService = membershipService;
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
    }
}
