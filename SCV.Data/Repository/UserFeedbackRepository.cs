namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class UserFeedbackRepository : BaseRepository<UserFeedback, int>, IUserFeedbackRepository
    {
        public UserFeedbackRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
