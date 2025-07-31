namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.TrainerVM;

    public interface ITrainerUserService
    {
        Task<IEnumerable<TrainerUserDetailViewModel>> GetTrainerUserListAsync(string userId);

        Task<IEnumerable<TrainerClientListViewModel>> AllClientsTrainerListAsync(string userId);

        Task<bool> AddUserToTrainer(string? trainerId, string userId);

        Task<bool> RemoveTrainerFromUserAsync(string? trainerId, string? userId);

        Task<bool> IsTrainerAddedToUserList(string? trainerId, string? userId);

    }
}
