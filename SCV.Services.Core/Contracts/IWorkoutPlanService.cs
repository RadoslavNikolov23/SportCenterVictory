namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.FitnessVM;

    public interface IWorkoutPlanService
    {
        Task<IEnumerable<WorkoutPlanDetailViewModel>> GetAllWorkoutPlansBySportType(SportType sportType);

    }
}
