namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IUserFeedbackRepository : IAsyncRepository<UserFeedback, Guid>, IRepository<UserFeedback, Guid>
    {
    }
}
