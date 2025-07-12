namespace SCV.Services.Core
{
    using SCV.Data;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.FitnessVM;

    public class ExerciseService : IExerciseService
    {
        private readonly SportCenterDbContext sportCenterDbContext;

        public ExerciseService(SportCenterDbContext sportCenterDbContext)
        {
            this.sportCenterDbContext = sportCenterDbContext;
        }

        public async Task<IEnumerable<ExercisesViewModel>>? GetAllExercises()
        {
            throw new NotImplementedException();
        }
    }
}
