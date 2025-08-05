namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.Services.Core.UserServices.Contracts;
    using SCV.Web.ViewModels.Administration.UserManagementVM;

    using static SCV.GlCommon.ApplicationConstants;

    public class UserManagementController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService userService)
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
                    TempData[ErrorMessageKey] = "User does not exist!";

                    return this.RedirectToAction(nameof(EditUserRole));
                }

                bool isAssayedRole = await this.userService
                    .AssignUserToRoleAsync(userId, role);

                if (!isAssayedRole)
                {
                    TempData[ErrorMessageKey] = "Something went wrong. Try Again later!";
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                TempData[SuccessMessageKey] = "User assigned to role successfully!";
                return this.RedirectToAction(nameof(EditUserRole));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while assaying role! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home", new { area = "" });
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
                    TempData[ErrorMessageKey] = "User does not exist!";
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                bool isRemovedRole = await this.userService
                    .RemoveUserRoleAsync(userId, role);

                if (!isRemovedRole)
                {
                    TempData[ErrorMessageKey] = "Something went wrong. Try Again later!";
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                TempData[SuccessMessageKey] = $"User removed from the given role {role} successfully!";
                return this.RedirectToAction(nameof(EditUserRole));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while removing role! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home", new { area = "" });
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
                    TempData[ErrorMessageKey] = "User does not exist!";
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                bool isDeletedUser = await this.userService
                    .DeleteUserAsync(userId);

                if (!isDeletedUser)
                {
                    TempData[ErrorMessageKey] = "Something went wrong. Try Again later!";
                    return this.RedirectToAction(nameof(EditUserRole));
                }

                TempData[SuccessMessageKey] = $"User deleted successfully!";
                return this.RedirectToAction(nameof(EditUserRole));

            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting user! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
    }
}
