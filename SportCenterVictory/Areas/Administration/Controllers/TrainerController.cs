namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TrainerController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
