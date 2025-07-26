namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class FitnessController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
