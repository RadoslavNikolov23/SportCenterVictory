namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SCV.Services.Core.EmailServices.Contracts;
    using SCV.Web.ViewModels.ContactVM;

    using static SCV.GlCommon.ApplicationConstants;

    public class ContactController : BaseController
    {
        private readonly IEmailService emailService;

        public ContactController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                bool isSend = await emailService.SendContactEmailAsync(model);

                if (!isSend)
                {
                    TempData[ErrorMessageKey] = "Message was now sent. Try again later!";
                    return RedirectToAction(nameof(Index));
                }

                TempData[SuccessMessageKey] = "Your message has been sent successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData[ErrorMessageKey] = $"Something wen wrong. Please try again. Message {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
