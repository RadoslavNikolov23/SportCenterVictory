namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MembershipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
