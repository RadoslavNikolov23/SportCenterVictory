namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Diagnostics;

    using SCV.GlCommon;
    using SCV.Web.Models;
    using SCV.Web.ViewModels.UserFeedbackVM;
    using SCV.Services.Core.UserFeedbackServices.Contracts;

    public class HomeController : BaseController<HomeController>
    {
        private readonly IUserFeedbackService userFeedbackService;

        public HomeController(IUserFeedbackService userFeedbackService, ILogger<HomeController> logger) : base(logger)
        {
            this.userFeedbackService = userFeedbackService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserFeedbackDetailViewModel> userFeedbackDetailVM = await this.userFeedbackService
                                    .GetAllUserFeedbacksAsync();

            if (userFeedbackDetailVM == null)
            {
                this.logger.LogInformation(ErrorMessages.NoUserFeedbacks);
                return View(new List<UserFeedbackDetailViewModel>());
            }

            return View(userFeedbackDetailVM);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        /* FOR TESTING PURPOSES ONLY */

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Test403()
        //{
        //    return StatusCode(403);
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Test500()
        //{
        //    return StatusCode(500);
        //}

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return this.View(ErrorViews.Error404);
                case 403:
                    return this.View(ErrorViews.Error403);
                case 500:
                    return this.View(ErrorViews.Error500);
                default:
                    return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
