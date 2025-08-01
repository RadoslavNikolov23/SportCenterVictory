namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IWorkoutPlanExerciseRepository : IAsyncRepository<WorkoutPlanExercise, (Guid, string)>, IRepository<WorkoutPlanExercise, (Guid, string)>
    {

        WorkoutPlanExercise? GetByCompositeKey(string workoutPlanId, string exerciseId);

        Task<WorkoutPlanExercise?> GetByCompositeKeyAsync(string workoutPlanId, string exerciseId);

        bool Exists(string workoutPlanId, string exerciseId);

        Task<bool> ExistsAsync(string workoutPlanId, string exerciseId);
    }
}
