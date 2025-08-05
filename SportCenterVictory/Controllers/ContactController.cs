namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Services.Core.EmailServices.Contracts;
    using SCV.Web.ViewModels.ContactVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public class ContactController : BaseController<ContactController>
    {
        private readonly IEmailService emailService;

        public ContactController(IEmailService emailService, ILogger<ContactController> logger) : base(logger)

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
        public async Task<IActionResult> Index(ContactFormViewModel contactVielModel)
        {
            if (!ModelState.IsValid)
                return View(contactVielModel);

            try
            {
                bool isSend = await emailService.SendContactEmailAsync(contactVielModel);

                if (!isSend)
                {
                    TempData[ErrorMessageKey] = ErrorMessageEmailSend;
                    return RedirectToAction(nameof(Index));
                }

                TempData[SuccessMessageKey] = SuccessMessageEmailSend;

                this.logger.LogInformation($"Successfully send Email from {contactVielModel.Email}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while sending contact form message. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
