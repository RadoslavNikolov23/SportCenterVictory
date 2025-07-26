namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class EventController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
