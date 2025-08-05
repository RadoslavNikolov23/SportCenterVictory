namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Collections.Generic;
    using SCV.Web.ViewModels.Administration.UserFeedbackVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;
    using SCV.Services.Core.UserFeedbackServices.Contracts;

    public class UserFeedbackController : BaseAdminController
    {
        private readonly IUserFeedbackService userFeedbackService;

        public UserFeedbackController(IUserFeedbackService userFeedbackService)
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
                    TempData[ErrorMessageKey] = "Invalid User Feedback. Please review the feedback!.";
                    return RedirectToAction(nameof(ApproveFeedback));
                }

                bool isApproved = await this.userFeedbackService
                                                .ApproveOrNotUserFeedbackAsync(feedbackVM);

                if (!isApproved)
                {
                    TempData[ErrorMessageKey] = "Could not update User Feedback. Please try again.";
                    return RedirectToAction(nameof(ApproveFeedback));

                }

                TempData[SuccessMessageKey] = "User Feedback status updated successfully!";
                return RedirectToAction(nameof(ApproveFeedback));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the User feedback! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
