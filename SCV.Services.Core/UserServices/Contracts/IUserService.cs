namespace SCV.Services.Core.UserServices.Contracts
{
    using SCV.Web.ViewModels.Administration.UserManagementVM;

    public interface IUserService
    {
        Task<IEnumerable<UserManagementIndexViewModel>> GetUserManagementBoardDataAsync(string userId);

        Task<bool> UserExistsByIdAsync(string userId);

        Task<bool> AssignUserToRoleAsync(string userId, string roleName);

        Task<bool> RemoveUserRoleAsync(string userId, string roleName);

        Task<bool> DeleteUserAsync(string userId);
    }
}
