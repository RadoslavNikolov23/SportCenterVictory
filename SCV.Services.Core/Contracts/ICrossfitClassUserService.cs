namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.CommonVM;

    public interface ICrossfitClassUserService
    {
        Task<IEnumerable<CrossfitClassUserDetailViewModel>> GetCrossfitClassUserListAsync(string userId);

        Task<bool> AddUserToCrossfitClass(string? crossfitClassId, string appUserId);

        Task<bool> RemoveUserFromCrossfitClassAsync(string? crossfitClassId, string? userId);

        Task<bool> IsUserAddedToCrossfitClasslist(string? crossfitClassId, string? userId);

    }
}
