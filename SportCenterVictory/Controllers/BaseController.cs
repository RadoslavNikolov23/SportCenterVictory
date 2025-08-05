namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Security.Claims;

    using SCV.GlCommon;

    [Authorize]
    public abstract class BaseController<T> : Controller
    {
        protected readonly ILogger<T> logger;

        public BaseController(ILogger<T> logger)
        {
            this.logger = logger;
        }

        protected bool IsUserAuthenticated()
        {
            bool isAuthenticated = User.Identity?.IsAuthenticated ?? false;

            return isAuthenticated;
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
