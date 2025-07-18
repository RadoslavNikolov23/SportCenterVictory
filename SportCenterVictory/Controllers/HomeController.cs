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

        public IActionResult Test403()
        {
            return StatusCode(403);
        }

        public IActionResult Test500()
        {
            return StatusCode(500);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return this.View("Error404");
                case 403:
                    return this.View("Error403");
                case 500:
                    return this.View("Error500");
                default:
                    return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
