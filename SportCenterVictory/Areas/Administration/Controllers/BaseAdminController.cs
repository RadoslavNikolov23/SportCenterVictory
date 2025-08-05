namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Security.Claims;

    using SCV.GlCommon;
    using static SCV.GlCommon.ApplicationConstants;

    [Area(AreaName)]
    [Authorize]
    public abstract class BaseAdminController<T> : Controller
    {
        protected readonly ILogger<T> logger;

        public BaseAdminController(ILogger<T> logger)
        {
            this.logger = logger;
        }

        private bool IsUserAuthenticated()
        {
            bool retRes = false;
            if (this.User.Identity != null)
            {
                retRes = this.User.Identity.IsAuthenticated;
            }

            return retRes;
        }

        protected string? GetUserId()
        {
            string? userId = null;
            if (this.IsUserAuthenticated())
            {
                userId = this.User
                    .FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
        protected IActionResult NotFoundWithMessage(string? message)
        {
            this.Response.StatusCode = 404;

            return View(ErrorViews.Error404, model: message);
        }

        protected IActionResult AccessForbiddenWithMessage(string? message)
        {
            this.Response.StatusCode = 403;

            return View(ErrorViews.Error403, model: message);
        }

        protected IActionResult ServerErrorWithMessage(string? message)
        {
            this.Response.StatusCode = 500;

            return View(ErrorViews.Error500, model: message);
        }
    }
}
