namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserFeedbackController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
