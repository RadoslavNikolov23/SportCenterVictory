namespace SportCenterVictory.Controllers
{
    using SCV.GlCommon;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public abstract class BaseController : Controller
    {
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
                userId= this.User
                    .FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }

        protected IActionResult NotFoundWithMessage(string message)
        {
            this.Response.StatusCode = 404;

            return View(ErrorViews.Error404, model: message);
        }
    }
}
