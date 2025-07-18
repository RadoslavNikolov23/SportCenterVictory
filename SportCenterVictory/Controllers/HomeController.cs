namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SportCenterVictory.Web.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserFeedbackService userFeedbackService;

        public HomeController(ILogger<HomeController> logger, IUserFeedbackService userFeedbackService)
        {
            this._logger = logger;
            this.userFeedbackService = userFeedbackService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserFeedbackDetailViewModel> userFeedbackDetailVM = await this.userFeedbackService
                                                        .GetAllUserFeedbacksAsync();

            return View(userFeedbackDetailVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
