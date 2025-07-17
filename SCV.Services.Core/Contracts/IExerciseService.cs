namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.FitnessVM;

    public interface IExerciseService
    {
        //See if this method is needed?
        public Task<IEnumerable<ExercisesIndexViewModel>> GetAllExercises();

        Task<IEnumerable<ExercisesIndexViewModel>> GetExercisesPageAsync(int page, int pageSize, string? query);

    }
}
