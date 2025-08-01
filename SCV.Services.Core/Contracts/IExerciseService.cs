namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.Administration.FitnessVM;
    using SCV.Web.ViewModels.FitnessVM;

    public interface IExerciseService
    {

        Task<ExercisesDetailViewModel?> GetExerciseByIdAsync(string id);

        //See if this method is needed?
        Task<IEnumerable<ExercisesDetailViewModel>> GetAllExercisesAsync();

        Task<IEnumerable<ExercisesDetailViewModel>> GetExercisesPageAsync(int page, int pageSize, string? query);

        Task<IEnumerable<ExerciseAdminDetailViewModel>> GetAllExerciseForAdminAsync();

        Task<bool> AddExerciseAsync(ExerciseAddViewModel exerciseToAddVM);

        Task<ExerciseEditViewModel?> GetExerciseForEditByIdAsync(string? id);

        Task<bool> EditExerciseAsync(ExerciseEditViewModel exerciseEditVM);

        Task<IEnumerable<ExerciseDeleteViewModel>> GetAllExerciseForDeletingAsync();

        Task<(bool, bool)> DeleteOrRestoreExerciseAsync(string? id);
    }
}
