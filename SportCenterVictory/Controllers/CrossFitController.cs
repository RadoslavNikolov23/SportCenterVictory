namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CrossFitController : Controller
    {
        public IActionResult CrossFitCenter()
        {
            return View();
        }
    }
}
