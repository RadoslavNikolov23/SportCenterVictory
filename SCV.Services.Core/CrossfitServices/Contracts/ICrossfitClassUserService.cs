namespace SCV.Services.Core.CrossfitServices.Contracts
{
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.CrossfitVM;

    public interface ICrossfitClassUserService
    {
        Task<IEnumerable<CrossfitClassUserDetailViewModel>> GetCrossfitClassUserListAsync(string userId);
        Task<bool> AddUserToCrossfitClass(string? crossfitClassId, string userId);

        Task<bool> RemoveUserFromCrossfitClassAsync(string? crossfitClassId, string? userId);

        Task<bool> IsUserAddedToCrossfitClassList(string? crossfitClassId, string? userId);

        Task<IEnumerable<UserCrossfitClassesForAdminListViewModel>> ForAdminCrossfitClassClientsListAsync();

    }
}
