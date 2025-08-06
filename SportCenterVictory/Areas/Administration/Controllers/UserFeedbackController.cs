namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Collections.Generic;

    using SCV.Web.ViewModels.Administration.UserFeedbackVM;
    using SCV.Services.Core.UserFeedbackServices.Contracts;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public class UserFeedbackController : BaseAdminController<UserFeedbackController>
    {
        private readonly IUserFeedbackService userFeedbackService;

        public UserFeedbackController(IUserFeedbackService userFeedbackService, ILogger<UserFeedbackController> logger) : base(logger)
        {
            this.userFeedbackService = userFeedbackService;
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ApproveFeedback()
        {
            IEnumerable<UserFeedbackApproveViewModel> allFeedbacks = await this.userFeedbackService
                                                .AllUserFeedbacksForApproveAsync();
            return View(allFeedbacks);
        }

        [HttpPost]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> UpdateFeedbackStatus(UserFeedbackApproveViewModel feedbackVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData[WarningMessageKey] = ErrorMessageInvalidUserFeedback;
                    return RedirectToAction(nameof(ApproveFeedback));
                }

                bool isApproved = await this.userFeedbackService
                                                .ApproveOrNotUserFeedbackAsync(feedbackVM);

                if (!isApproved)
                {
                    this.logger.LogWarning($"Error occurred in the services methods while trying to approve a User Feedback, with ID: {feedbackVM.Id}.");
                    
                    TempData[WarningMessageKey] = ErrorMessageCannotApproveUserFeedback;
                    return RedirectToAction(nameof(ApproveFeedback));

                }

                this.logger.LogInformation($"Successfully approve new Feedback with ID: {feedbackVM.Id} from {feedbackVM.FullName}.");
                
                TempData[SuccessMessageKey] = SuccessMessageApproveUserFeedback;
                return RedirectToAction(nameof(ApproveFeedback));
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while editing the User feedback!. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
