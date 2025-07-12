namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.FitnessVM;

    public interface IExerciseService
    {
        public Task<IEnumerable<ExercisesViewModel>>? GetAllExercises();
    }
}
