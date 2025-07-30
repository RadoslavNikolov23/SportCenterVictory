namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UserPanelController : BaseController
    {
        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> LeaveFeedback()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> JoinedCrossfitClasses()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> JoinedEvents()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> FavoriteTrainers()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> PurchasedMemberships()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> MadeOrders()
        {
            return View();
        }
    }
}
