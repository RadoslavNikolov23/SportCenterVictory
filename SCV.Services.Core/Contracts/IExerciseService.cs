namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.FitnessVM;

    public interface IExerciseService
    {

        Task<ExercisesDetailViewModel?> GetExerciseByIdAsync(string id);

        //See if this method is needed?
        Task<IEnumerable<ExercisesDetailViewModel>> GetAllExercisesAsync();

        Task<IEnumerable<ExercisesDetailViewModel>> GetExercisesPageAsync(int page, int pageSize, string? query);

    }
}
