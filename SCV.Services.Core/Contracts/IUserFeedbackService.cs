namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.UserFeedbackVM;

    public interface IUserFeedbackService
    {
        Task<IEnumerable<UserFeedbackDetailViewModel>> GetAllUserFeedbacksAsync();

        Task<bool> AddUserFeedbackAsync(UserFeedbackAddViewModel userFeedbackToAddVM);
    }
}
