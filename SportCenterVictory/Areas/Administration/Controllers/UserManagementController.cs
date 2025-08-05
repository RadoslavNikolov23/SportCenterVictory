namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using SCV.Services.Core.UserServices.Contracts;
    using SCV.Web.ViewModels.Administration.UserManagementVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public class UserManagementController : BaseAdminController<UserManagementController>
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService userService, ILogger<UserManagementController> logger) : base(logger)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> EditUserRole()
        {
            IEnumerable<UserManagementIndexViewModel> allUsers = await this.userService
                                    .GetUserManagementBoardDataAsync(this.GetUserId()!);

            return View(allUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            try
            {
                bool userExists = await this.userService
                                .UserExistsByIdAsync(userId);

                if (!userExists)
                {
                    this.logger.LogWarning($"Cannot assign a role to user with ID: {userId}.");
                    TempData[ErrorMessageKey] = ErrorMessageUserDoesNotExist;
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                bool isAssayedRole = await this.userService
                    .AssignUserToRoleAsync(userId, role);

                if (!isAssayedRole)
                {
                    this.logger.LogWarning($"Error in the Service methods, Cannot assign a role to user with ID: {userId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                this.logger.LogInformation($"Successfully assing {role} to user with ID{userId}!.");

                TempData[SuccessMessageKey] = SuccessMessageAssinRoleUser;
                return this.RedirectToAction(nameof(EditUserRole));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while assaying role to a user. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string role)
        {
            try
            {
                bool userExists = await this.userService
                    .UserExistsByIdAsync(userId);

                if (!userExists)
                {
                    this.logger.LogWarning($"Cannot remove a role to user with ID: {userId}.");
                    TempData[ErrorMessageKey] = ErrorMessageUserDoesNotExist;
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                bool isRemovedRole = await this.userService
                    .RemoveUserRoleAsync(userId, role);

                if (!isRemovedRole)
                {
                    this.logger.LogWarning($"Error in the Service methods, Cannot remove a role to user with ID: {userId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                this.logger.LogInformation($"Successfully removed {role} to user with ID{userId}!.");

                TempData[SuccessMessageKey] = string.Format(SuccessMessageRemoveRoleUser, role);
                return this.RedirectToAction(nameof(EditUserRole));
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while removing role from a user with ID:{userId}. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                bool userExists = await this.userService
                    .UserExistsByIdAsync(userId);

                if (!userExists)
                {
                    this.logger.LogWarning($"Cannot delete user with ID: {userId}.");
                    TempData[ErrorMessageKey] = ErrorMessageUserDoesNotExist;
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                bool isDeletedUser = await this.userService
                    .DeleteUserAsync(userId);

                if (!isDeletedUser)
                {
                    this.logger.LogWarning($"Error in the Service methods, Cannot remove a role to user with ID: {userId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                TempData[SuccessMessageKey] = SuccessMessageDeleteUser;
                return this.RedirectToAction(nameof(EditUserRole));

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while trying to delete user with ID: {userId}. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
