namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.FitnessVM;
    using SCV.GlCommon.Enums;

    public class WorkoutPlanService : IWorkoutPlanService
    {
        public readonly IWorkoutPlanRepository workoutPlanRepo;

        public WorkoutPlanService(IWorkoutPlanRepository workoutPlanRepo)
        {
            this.workoutPlanRepo = workoutPlanRepo;
        }

        public async Task<IEnumerable<WorkoutPlanDetailViewModel>> GetAllWorkoutPlansBySportTypeAsync(SportType sportType)
        {
            IEnumerable<WorkoutPlanDetailViewModel> workoutPlanDetailVM = await this.workoutPlanRepo
                                    .GetAllAttached()
                                    .Include(wp=>wp.WorkoutPlanExercises)
                                    .AsNoTracking()
                                    .Where(wp=>wp.Type == sportType)
                                    .Select(wp => new WorkoutPlanDetailViewModel()
                                    {
                                        Id = wp.Id,
                                        Title = wp.Title,
                                        Description = wp.Description,
                                        Type = wp.Type,
                                        ImageUrl = wp.ImageUrl ?? $"/imagesExercises/fallback.jpg",
                                        WorkoutPlanExercisesVM = wp.WorkoutPlanExercises
                                                                    .Where(wpe=> wpe.WorkoutPlanId == wp.Id)
                                                                    .Select(wpe => new WorkoutPlanExerciseDetailViewModel()
                                                                    {
                                                                        ExerciseId = wpe.ExerciseId,
                                                                        ExerciseName = wpe.Exercise.Name
                                                                    })
                                                                    .ToList()
                                    })
                                    .ToListAsync();

            return workoutPlanDetailVM;
        }
    }
}
