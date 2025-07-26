namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CrossfitController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
