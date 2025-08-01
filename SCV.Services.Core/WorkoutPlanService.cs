namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.FitnessVM;
    using SCV.Web.ViewModels.FitnessVM;

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
                                    .Include(wp => wp.WorkoutPlanExercises)
                                    .AsNoTracking()
                                    .Where(wp => wp.Type == sportType)
                                    .Select(wp => new WorkoutPlanDetailViewModel()
                                    {
                                        Id = wp.Id.ToString(),
                                        Title = wp.Title,
                                        Description = wp.Description,
                                        Type = wp.Type,
                                        //TODO:Check why this goes to fallback.jpg
                                        ImageUrl = wp.ImageUrl ?? $"/imagesExercises/fallback.jpg",
                                        WorkoutPlanExercisesVM = wp.WorkoutPlanExercises
                                                                    .Where(wpe => wpe.WorkoutPlanId == wp.Id)
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
        public async Task<IEnumerable<WorkoutPlanAdminDetailViewModel>> GetAllWorkoutPlansForAdminAsync()
        {
            IEnumerable<WorkoutPlanAdminDetailViewModel> workoutPlansAdminDetailVM = await
                                                    this.workoutPlanRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .Select(wp => new WorkoutPlanAdminDetailViewModel()
                                                    {
                                                        Id = wp.Id.ToString(),
                                                        Title = wp.Title,
                                                    })
                                                    .ToListAsync();

            return workoutPlansAdminDetailVM;

        }

        public async Task<bool> AddWorkoutPlanAsync(WorkoutPlanAddViewModel workoutPlanAddVM)
        {
            bool isAdded = false;

            if (workoutPlanAddVM != null)
            {
                WorkoutPlan workoutPanToAdd = new WorkoutPlan
                {
                    Title = workoutPlanAddVM.Title,
                    Description = workoutPlanAddVM.Description,
                    Type = workoutPlanAddVM.Type,
                    ImageUrl = workoutPlanAddVM.ImageUrl,

                };

                await this.workoutPlanRepo.AddAsync(workoutPanToAdd);
                isAdded = true;
            }

            return isAdded;
        }

        public async Task<WorkoutPlanEditViewModel?> GetWorkoutPlanByIdAsync(string? id)
        {
            WorkoutPlanEditViewModel? workoutPlanEditVM = null;

            if (!string.IsNullOrEmpty(id))
            {
                WorkoutPlan? workoutPlanEntity = await this.workoutPlanRepo
                                    .GetAllAttached()
                                    .SingleOrDefaultAsync(wp => wp.Id.ToString().ToLower() == id.ToLower());

                if (workoutPlanEntity != null)
                {
                    workoutPlanEditVM = new WorkoutPlanEditViewModel()
                    {
                        Id = workoutPlanEntity.Id.ToString(),
                        Title = workoutPlanEntity.Title,
                        Description = workoutPlanEntity.Description,
                        Type = workoutPlanEntity.Type,
                        ImageUrl = workoutPlanEntity.ImageUrl,
                    };
                }
            }

            return workoutPlanEditVM;
        }

        public async Task<bool> EditWorkoutPlanAsync(WorkoutPlanEditViewModel workoutPlanEditVM)
        {
            bool isEdited = false;

            if (workoutPlanEditVM == null)
            {
                return isEdited;
            }

            WorkoutPlan? workoutPanEntity = await this.workoutPlanRepo
                                        .GetAllAttached()
                                        .SingleOrDefaultAsync(wp => wp.Id.ToString().ToLower() == workoutPlanEditVM.Id.ToLower());

            if (workoutPanEntity != null)
            {
                workoutPanEntity.Title = workoutPlanEditVM.Title;
                workoutPanEntity.Description = workoutPlanEditVM.Description;
                workoutPanEntity.Type = workoutPlanEditVM.Type;
                workoutPanEntity.ImageUrl = workoutPlanEditVM.ImageUrl;

                isEdited = await this.workoutPlanRepo
                                        .UpdateAsync(workoutPanEntity);
            }

            return isEdited;
        }

        public async Task<IEnumerable<WorkoutPlanDeleteViewModel>> GetAllWorkoutPlanForDeletingAsync()
        {
            IEnumerable<WorkoutPlanDeleteViewModel> listWorkoutPansDeleteVM = await this.workoutPlanRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Select(wp => new WorkoutPlanDeleteViewModel()
                                                    {
                                                        Id = wp.Id.ToString(),
                                                        Title = wp.Title,
                                                        Type = wp.Type,
                                                        IsDeleted = wp.IsDeleted
                                                    })
                                                    .ToListAsync();

            return listWorkoutPansDeleteVM;
        }

        public async Task<(bool, bool)> DeleteOrRestoreWorkoutPlanAsync(string? id)
        {
            bool result = false;
            bool isRestored = false;

            if (!String.IsNullOrWhiteSpace(id))
            {
                WorkoutPlan? workoutPlanEntity = await this.workoutPlanRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(wp => wp.Id.ToString().ToLower() == id.ToLower());

                if (workoutPlanEntity != null)
                {
                    if (!workoutPlanEntity.IsDeleted)
                    {
                        isRestored = true;
                    }

                    workoutPlanEntity.IsDeleted = !workoutPlanEntity.IsDeleted;

                    result = await this.workoutPlanRepo
                                    .UpdateAsync(workoutPlanEntity);
                }
            }

            return (result, isRestored);
        }
    }
}
