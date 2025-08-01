namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;

    public class WorkoutPlanExerciseService : IWorkoutPlanExerciseService
    {
        public readonly IWorkoutPlanExerciseRepository workoutPlanExerciseRepo;

        public WorkoutPlanExerciseService(IWorkoutPlanExerciseRepository workoutPlanExerciseRepo)
        {
            this.workoutPlanExerciseRepo = workoutPlanExerciseRepo;
        }

        public async Task<List<string>> GetExerciseIdsForWorkoutPlanAsync(string workoutPlanId)
        {
            throw new NotImplementedException("This method is not implemented yet.");
            //return await this.dbContext.WorkoutPlanExercises
            //    .Where(x => x.WorkoutPlanId.ToString() == workoutPlanId)
            //    .Select(x => x.ExerciseId)
            //    .ToListAsync();
        }

        public async Task UpdateExercisesForWorkoutPlanAsync(string workoutPlanId, List<string> exerciseIds)
        {
            throw new NotImplementedException("This method is not implemented yet.");

            //var existing = await dbContext.WorkoutPlanExercises
            //    .Where(x => x.WorkoutPlanId.ToString() == workoutPlanId)
            //    .ToListAsync();

            //dbContext.WorkoutPlanExercises.RemoveRange(existing);

            //var newLinks = exerciseIds.Select(eid => new WorkoutPlanExercise
            //{
            //    WorkoutPlanId = Guid.Parse(workoutPlanId),
            //    ExerciseId = eid
            //});

            //await dbContext.WorkoutPlanExercises.AddRangeAsync(newLinks);
            //await dbContext.SaveChangesAsync();
        }



    }
}
