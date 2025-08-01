namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.FitnessVM;
    using SCV.Web.ViewModels.FitnessVM;

    public interface IWorkoutPlanService
    {
        Task<IEnumerable<WorkoutPlanDetailViewModel>> GetAllWorkoutPlansBySportTypeAsync(SportType sportType);

        Task<IEnumerable<WorkoutPlanAdminDetailViewModel>> GetAllWorkoutPlansForAdminAsync();

        Task<bool> AddWorkoutPlanAsync(WorkoutPlanAddViewModel workoutPlanAddVM);

        Task<WorkoutPlanEditViewModel?> GetWorkoutPlanByIdAsync(string? id);

        Task<bool> EditWorkoutPlanAsync(WorkoutPlanEditViewModel workoutPlanEditVM);

        Task<IEnumerable<WorkoutPlanDeleteViewModel>> GetAllWorkoutPlanForDeletingAsync();

        Task<(bool, bool)> DeleteOrRestoreWorkoutPlanAsync(string? id);

    }
}
