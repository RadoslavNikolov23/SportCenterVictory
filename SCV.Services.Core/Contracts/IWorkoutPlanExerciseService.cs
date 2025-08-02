namespace SCV.Services.Core.Contracts
{
    public interface IWorkoutPlanExerciseService
    {
        Task<List<string>> GetExerciseIdsForWorkoutPlanAsync(string workoutPlanId);

        Task UpdateExercisesForWorkoutPlanAsync(string workoutPlanId, ICollection<string> exerciseIds);
    }
}
