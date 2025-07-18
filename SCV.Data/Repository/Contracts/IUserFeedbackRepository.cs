namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IUserFeedbackRepository : IAsyncRepository<UserFeedback, int>, IRepository<UserFeedback, int>
    {
    }
}
