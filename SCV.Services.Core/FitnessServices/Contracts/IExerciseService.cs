namespace SCV.Services.Core.FitnessServices.Contracts
{
    using SCV.Web.ViewModels.Administration.FitnessVM;
    using SCV.Web.ViewModels.FitnessVM;

    public interface IExerciseService
    {

        Task<ExercisesDetailViewModel?> GetExerciseByIdAsync(string id);

        Task<IEnumerable<ExercisesDetailViewModel>> GetAllExercisesAsync();

        Task<IEnumerable<ExercisesDetailViewModel>> GetExercisesPageAsync(int page, int pageSize, string? query);

        Task<IEnumerable<ExerciseAdminDetailViewModel>> GetAllExerciseForAdminAsync();

        Task<bool> AddExerciseAsync(ExerciseAddViewModel exerciseToAddVM);

        Task<ExerciseEditViewModel?> GetExerciseForEditByIdAsync(string? id);

        Task<bool> EditExerciseAsync(ExerciseEditViewModel exerciseEditVM);

        Task<ExerciseDeletePageViewModel> GetAllExerciseForDeletingByPageAsync(int page, string? searchTerm);
        Task<(bool, bool)> DeleteOrRestoreExerciseAsync(string? id);
    }
}
