namespace SCV.Data.Repository
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class WorkoutPlanExerciseRepository : BaseRepository<WorkoutPlanExercise, (Guid, string)>, IWorkoutPlanExerciseRepository
    {
        public WorkoutPlanExerciseRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }


        public Task<WorkoutPlanExercise?> GetByCompositeKeyAsync(string workoutPlanId, string exerciseId)
        {
            return this.GetAllAttached()
                        .SingleOrDefaultAsync(wp => wp.WorkoutPlanId.ToString().ToLower() == workoutPlanId.ToLower() &&
                        wp.ExerciseId.ToString().ToLower() == exerciseId.ToLower());
        }

        public Task<bool> ExistsAsync(string workoutPlanId, string exerciseId)
        {
            return this.GetAllAttached()
                .AnyAsync(wp => wp.WorkoutPlanId.ToString().ToLower() == workoutPlanId.ToLower() &&
                        wp.ExerciseId.ToString().ToLower() == exerciseId.ToLower());
        }

        public WorkoutPlanExercise? GetByCompositeKey(string workoutPlanId, string exerciseId)
        {
            return this.GetAllAttached()
                    .SingleOrDefault(wp => wp.WorkoutPlanId.ToString().ToLower() == workoutPlanId.ToLower() &&
                        wp.ExerciseId.ToString().ToLower() == exerciseId.ToLower());
        }

        public bool Exists(string workoutPlanId, string exerciseId)
        {
            return this.GetAllAttached()
                .Any(wp => wp.WorkoutPlanId.ToString().ToLower() == workoutPlanId.ToLower() &&
                        wp.ExerciseId.ToString().ToLower() == exerciseId.ToLower());
        }

    }
}
