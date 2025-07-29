namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.CommonVM;

    public interface IEventUserService
    {
        Task<IEnumerable<EventUserDetailViewModel>> GetEventUserListAsync(string userId);

        Task<bool> AddUserToEvent(string? eventId, string appUserId);

        Task<bool> RemoveUserFromEventAsync(string? eventId, string? userId);

        Task<bool> IsUserAddedToEventlist(string? eventId, string? userId);

    }
}
