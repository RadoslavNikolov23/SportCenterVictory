namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserManagementController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
