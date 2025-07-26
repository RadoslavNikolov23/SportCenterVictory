namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class WorkoutPlanRepository : BaseRepository<WorkoutPlan, Guid>, IWorkoutPlanRepository
    {
        public WorkoutPlanRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
