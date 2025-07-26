namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserFeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
