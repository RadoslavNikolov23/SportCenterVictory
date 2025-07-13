namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.FitnessVM;

    public interface IExerciseService
    {
        public Task<IEnumerable<ExercisesIndexViewModel>> GetAllExercises();

        Task<IEnumerable<ExercisesIndexViewModel>> GetExercisesPageAsync(int page, int pageSize, string? query);
    }
}
