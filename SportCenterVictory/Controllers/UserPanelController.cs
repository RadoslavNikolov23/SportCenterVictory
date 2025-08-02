namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Data.Models;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CrossfitVM;
    using SCV.Web.ViewModels.UserFeedbackVM;

    using static SCV.GlCommon.ApplicationConstants;


    public partial class UserPanelController : BaseController
    {
        private readonly IEventUserService eventUserService;
        private readonly IOrderService orderService;
        private readonly ICrossfitClassUserService crossfitClassUserService;
        private readonly IMembershipUserService membershipUserService;
        private readonly ITrainerUserService trainerUserService;
        private readonly IUserFeedbackService userFeedbackService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserPanelController(IEventUserService eventUserService, ICrossfitClassUserService crossfitClassUserService,
        IMembershipUserService membershipUserService, ITrainerUserService trainerUserService,
        IUserFeedbackService userFeedbackService, IOrderService orderService, UserManager<ApplicationUser> userManager)
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
            //TODO: use the methods in the BaseController
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData[ErrorMessageKey] = "Unable to find user.";
                return RedirectToAction("Index", "Home");
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
                    TempData[ErrorMessageKey] = "User not found.";
                    return RedirectToAction("Index", "Home");
                }

                // Overwrite with current user data to avoid tampering
                userFeedbackAddVM.UserId = user.Id.ToString();
                userFeedbackAddVM.UserName = user.UserName!;
                userFeedbackAddVM.FullName = user.FullName;

                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    return this.View(userFeedbackAddVM);
                }

                bool isAddedSuccessfully = await this.userFeedbackService
                    .AddUserFeedbackAsync(userFeedbackAddVM);

                if (!isAddedSuccessfully)
                {
                    TempData[ErrorMessageKey] = "User Feedback could not be created. Please try again.";

                    return View(userFeedbackAddVM);
                }


                TempData[SuccessMessageKey] = "User Feedback added successfully!";
                return RedirectToAction("Index", "Home", new { area = "" });


            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while adding the User Feedback! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
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
                    return this.Forbid();
                }

                IEnumerable<CrossfitClassUserDetailViewModel> crossfitClassUserList = await this.crossfitClassUserService.GetCrossfitClassUserListAsync(userId);

                foreach (CrossfitClassUserDetailViewModel crossfitClassUserVM in crossfitClassUserList)
                {
                    crossfitClassUserVM.IsUserJoined = await this.crossfitClassUserService
                        .IsUserAddedToCrossfitClassList(crossfitClassUserVM.CrossfitClassId, this.GetUserId());
                }

                return View(crossfitClassUserList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinCrossfitClass(string? crossfitClassId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (crossfitClassId == null)
                {
                    //TODO: Redirect to the same action detail
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses));
                    //Or ad this   return this.Forbid();
                }

                bool isCrossfitClassJoinedByUser = await this.crossfitClassUserService
                                      .AddUserToCrossfitClass(crossfitClassId, userId);

                if (isCrossfitClassJoinedByUser == false)
                {
                    // TODO: Add JS notifications and fix this!
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses), "UserPanel");
                }

                // Also TODO this:
                return this.RedirectToAction(nameof(JoinedCrossfitClasses));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCrossfitClass(string? crossfitClassId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (crossfitClassId == null)
                {
                    //TODO: Redirect to the same action detail
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses));
                    //Or ad this   return this.Forbid();
                }

                bool isRemovedUserFromCrossfitClass = await this.crossfitClassUserService
                                     .RemoveUserFromCrossfitClassAsync(crossfitClassId, userId);

                if (isRemovedUserFromCrossfitClass == false)
                {
                    // If the recipe was not removed from favorites, we still redirect to the same page by default by the requirements.
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses), "UserPanel");
                }

                return this.RedirectToAction(nameof(JoinedCrossfitClasses));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        //Trainer actions and Events actions are in the partial UserPanelController.EventTrainer.cs ->

        //Store - Membership actions and Product actions are in the partial UserPanelController.Store.cs ->
    }
}
