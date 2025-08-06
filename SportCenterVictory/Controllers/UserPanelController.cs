namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Data.Models;
    using SCV.Services.Core.CrossfitServices.Contracts;
    using SCV.Services.Core.EventServices.Contracts;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Services.Core.UserFeedbackServices.Contracts;
    using SCV.Web.ViewModels.CrossfitVM;
    using SCV.Web.ViewModels.UserFeedbackVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public partial class UserPanelController : BaseController<UserPanelController>
    {
        private readonly IEventUserService eventUserService;
        private readonly IOrderService orderService;
        private readonly ICrossfitClassUserService crossfitClassUserService;
        private readonly IMembershipUserService membershipUserService;
        private readonly ITrainerUserService trainerUserService;
        private readonly IUserFeedbackService userFeedbackService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserPanelController(IEventUserService eventUserService, ICrossfitClassUserService crossfitClassUserService, IMembershipUserService membershipUserService, ITrainerUserService trainerUserService, IUserFeedbackService userFeedbackService, IOrderService orderService, UserManager<ApplicationUser> userManager, ILogger<UserPanelController> logger) : base(logger)
        {
            this.eventUserService = eventUserService;
            this.crossfitClassUserService = crossfitClassUserService;
            this.membershipUserService = membershipUserService;
            this.trainerUserService = trainerUserService;
            this.userFeedbackService = userFeedbackService;
            this.userManager = userManager;
            this.orderService = orderService;
        }


        //-------------------UserFeedback--------------------------------------

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> LeaveFeedback()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                this.logger.LogWarning(UnableToFindUser);
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }

            UserFeedbackAddViewModel userFeedbackAddVM = new UserFeedbackAddViewModel
            {
                UserId = user.Id.ToString(),
                UserName = user.UserName!,
                FullName = user.FullName,
            };

            return View(userFeedbackAddVM);
        }


        [HttpPost]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> LeaveFeedback(UserFeedbackAddViewModel userFeedbackAddVM)
        {
            try
            {
                var user = await userManager.GetUserAsync(User);

                if (user == null)
                {
                    this.logger.LogWarning(UnableToFindUser);
                    return this.ServerErrorWithMessage(BaseServerErrorMessage);
                }

                userFeedbackAddVM.UserId = user.Id.ToString();
                userFeedbackAddVM.UserName = user.UserName!;
                userFeedbackAddVM.FullName = user.FullName;

                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, SomethingWentWrong);

                    return this.View(userFeedbackAddVM);
                }

                bool isAddedSuccessfully = await this.userFeedbackService
                    .AddUserFeedbackAsync(userFeedbackAddVM);

                if (!isAddedSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred in the service method while adding User Feedback by user with Id: {user.Id.ToString()}.");
                    TempData[ErrorMessageKey] = ErrorMessageUserFeedbackCannotCreate;
                    return View(userFeedbackAddVM);
                }


                TempData[SuccessMessageKey] = SuccessMessageUserFeedbackSuccessfulAdd;
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while adding the User Feedback from User. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        //-------------------CrossfitClasses--------------------------------------

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> JoinedCrossfitClasses()
        {
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                IEnumerable<CrossfitClassUserDetailViewModel> crossfitClassUserList = await this.crossfitClassUserService
                                        .GetCrossfitClassUserListAsync(userId);

                return View(crossfitClassUserList);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while loading Joined Crossfit Classes from User with ID: {this.GetUserId()}. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinCrossfitClass(string? crossfitClassId, string? returnUrl)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (crossfitClassId == null)
                {
                    this.logger.LogWarning($"Error occurred while joining Crossfit Class with ID: {crossfitClassId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses));
                }

                bool isCrossfitClassJoinedByUser = await this.crossfitClassUserService
                                      .AddUserToCrossfitClass(crossfitClassId, userId);

                if (isCrossfitClassJoinedByUser == false)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while joining Crossfit Class with ID: {crossfitClassId} from user with ID:{userId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses));
                }
                TempData[SuccessMessageKey] = SuccessMessageJoinedCrossfitClass;

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return this.RedirectToAction("CrossFitClasses", "CrossFit");
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while joining Crossfit Class with ID: {crossfitClassId} from user with ID:{this.GetUserId()}. Error: {e.Message}.");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCrossfitClass(string? crossfitClassId, string? returnUrl)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (crossfitClassId == null)
                {
                    this.logger.LogWarning($"Error occurred while removing Crossfit Class with ID: {crossfitClassId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses));
                }

                bool isRemovedUserFromCrossfitClass = await this.crossfitClassUserService
                                     .RemoveUserFromCrossfitClassAsync(crossfitClassId, userId);

                if (isRemovedUserFromCrossfitClass == false)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while removing Crossfit Class with ID: {crossfitClassId} from user with ID:{userId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses));
                }


                TempData[SuccessMessageKey] = SuccessMessageRemovedCrossfitClass;

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return this.RedirectToAction(nameof(JoinedCrossfitClasses));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while removing Crossfit Class with ID: {crossfitClassId} from user with ID:{this.GetUserId()}. Error: {e.Message}.");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        /*
                    ==============================================================
                    ===== Trainer actions and Events actions are in the partial ==
                    ===== UserPanelController.EventTrainer.cs ---->             ==
                    ==============================================================
        */

        /*
                    =============================================================
                    === Store - Membership actions and Product actions         ==
                    === are in the partial UserPanelController.Store.cs --->   ==
                    =============================================================
        */
    }
}
