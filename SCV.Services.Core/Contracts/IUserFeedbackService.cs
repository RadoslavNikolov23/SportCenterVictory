namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.CommonVM;

    public interface IUserFeedbackService
    {
        Task<IEnumerable<UserFeedbackDetailViewModel>> GetAllUserFeedbacksAsync();
    }
}
