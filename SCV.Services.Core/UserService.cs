namespace SCV.Services.Core
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.UserManagementVM;

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly ITrainerRepository trainerRepo;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ITrainerRepository trainerRepo)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.trainerRepo = trainerRepo;
        }

        public async Task<IEnumerable<UserManagementIndexViewModel>> GetUserManagementBoardDataAsync(string userId)
        {
            IEnumerable<UserManagementIndexViewModel> users = await this.userManager
                .Users
                .Where(u => u.Id.ToString().ToLower() != userId.ToLower())
                .Select(u => new UserManagementIndexViewModel
                {
                    Id = u.Id.ToString(),
                    Email = u.Email!,
                    Roles = userManager.GetRolesAsync(u)
                        .GetAwaiter()
                        .GetResult()
                })
                .ToListAsync();

            return users;
        }

        public async Task<bool> UserExistsByIdAsync(string userId)
        {
            ApplicationUser? user = await this.userManager
                        .FindByIdAsync(userId);

            return user != null;
        }

        public async Task<bool> AssignUserToRoleAsync(string userId, string roleName)
        {
            ApplicationUser? user = await this.userManager
                .FindByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException("User does not exist!");
            }

            bool roleExists = await this.roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                throw new ArgumentException("Selected role is not a valid role!");
            }

            try
            {
                await this.userManager.AddToRoleAsync(user, roleName);

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(
                    "Unexpected error occurred while adding the user to role! Please try again later!",
                    innerException: e);
            }
        }

        public async Task<bool> RemoveUserRoleAsync(string userId, string roleName)
        {
            ApplicationUser? user = await userManager
                .FindByIdAsync(userId);

            bool roleExists = await this.roleManager.RoleExistsAsync(roleName);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);
            if (alreadyInRole)
            {
                IdentityResult? result = await this.userManager
                    .RemoveFromRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            ApplicationUser? user = await userManager
                            .FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            Trainer? trainer = await this.trainerRepo
                     .SingleOrDefaultAsync(t => t.ApplicationUserId!.ToString().ToLower() == userId.ToLower());

            if (trainer != null)
            {
                bool isDeleted = await this.trainerRepo
                    .HardDeleteAsync(trainer);

                if (!isDeleted)
                {
                    return false;
                }
            }

            IdentityResult? result = await this.userManager
                .DeleteAsync(user);

            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}
