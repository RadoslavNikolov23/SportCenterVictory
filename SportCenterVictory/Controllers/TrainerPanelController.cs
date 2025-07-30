namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static SCV.GlCommon.RoleConstants;

    public class TrainerPanelController : BaseController
    {
        [HttpGet]
        [Authorize(Roles = Trainer)]
        public async Task<IActionResult> UserClientList()
        {
            return View();
        }
    }
}
