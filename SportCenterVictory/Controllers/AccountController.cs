namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using SCV.Data.Models;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.ToastMessages;

    public class AccountController : BaseController<AccountController>
    {
        private readonly SignInManager<ApplicationUser> signInManager;


        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger) : base(logger)
        {
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            TempData[SuccessMessageKey] = SuccessfulLogOut;

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {area = ""});
        }
    }
}
