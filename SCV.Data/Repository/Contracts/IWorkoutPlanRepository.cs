namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IWorkoutPlanRepository : IAsyncRepository<WorkoutPlan, int>, IRepository<WorkoutPlan, int>
    {

    }
}
