namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class StoreController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
