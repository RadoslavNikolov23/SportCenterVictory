namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class WorkoutPlanRepository : BaseRepository<WorkoutPlan, int>, IWorkoutPlanRepository
    {
        public WorkoutPlanRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
