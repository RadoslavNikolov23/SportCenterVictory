namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;

    public class WorkoutPlanExerciseService : IWorkoutPlanExerciseService
    {
        public readonly IWorkoutPlanExerciseRepository workoutPlanExerciseRepo;
        public readonly IWorkoutPlanRepository workoutPlanRepo;

        public WorkoutPlanExerciseService(IWorkoutPlanExerciseRepository workoutPlanExerciseRepo, IWorkoutPlanRepository workoutPlanRepo)
        {
            this.workoutPlanExerciseRepo = workoutPlanExerciseRepo;
            this.workoutPlanRepo = workoutPlanRepo;
        }

        public async Task<List<string>> GetExerciseIdsForWorkoutPlanAsync(string workoutPlanId)
        {
            return await this.workoutPlanExerciseRepo
                        .GetAllAttached()
                        .Where(x => x.WorkoutPlanId.ToString().ToLower() == workoutPlanId.ToLower())
                        .Select(x => x.ExerciseId)
                        .ToListAsync();
        }

        public async Task UpdateExercisesForWorkoutPlanAsync(string workoutPlanId, ICollection<string> exerciseIds)
        {
            if (string.IsNullOrWhiteSpace(workoutPlanId))
            {
                throw new ArgumentNullException(nameof(workoutPlanId), "Workout Plan ID cannot be null or empty.");
            }

            bool isWorkoutPlanGuided = Guid.TryParse(workoutPlanId, out Guid workoutPlanGuid);

            if (!isWorkoutPlanGuided)
            {
                throw new ArgumentNullException(nameof(workoutPlanId), "Workout Plan ID cannot be null or empty.");
            }

            if (exerciseIds == null)
            {
                throw new ArgumentNullException(nameof(exerciseIds), "Exercise ID list cannot be null.");
            }


            // 1. Get all existing links for this workout plan
            ICollection<WorkoutPlanExercise> existingLinks = await this.workoutPlanExerciseRepo
                .GetAllAttached()
                .Where(wpe => wpe.WorkoutPlanId == workoutPlanGuid)
                .ToListAsync();

            // 2. Delete them in bulk
            if (existingLinks.Any())
            {
                await this.workoutPlanExerciseRepo.HardDeleteRangeAsync(existingLinks);
            }

            // 3. Add new links
            if (exerciseIds.Any())
            {
                IEnumerable<WorkoutPlanExercise> newExercisesAttached = exerciseIds
                                .Select(eid => new WorkoutPlanExercise
                                        {
                                            WorkoutPlanId = workoutPlanGuid,
                                            ExerciseId = eid
                                        });

                await this.workoutPlanExerciseRepo.AddRangeAsync(newExercisesAttached);
            }

        }



    }
}
