namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.CommonVM;

    public interface IMembershipUserService
    {
        Task<IEnumerable<MembershipUserDetailViewModel>> GetMembershipUserListAsync(string userId);

        Task<bool> AddUserToMembership(string? membershipId, string appUserId);

        Task<bool> RemoveUserFromMembershipAsync(string? membershipId, string? userId);

        Task<bool> IsUserAddedToMembershipList(string? membershipId, string? userId);

    }
}
