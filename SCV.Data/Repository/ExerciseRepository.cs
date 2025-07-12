namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class ExerciseRepository : BaseRepository<Exercise, string>, IExerciseRepository
    {
        public ExerciseRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
