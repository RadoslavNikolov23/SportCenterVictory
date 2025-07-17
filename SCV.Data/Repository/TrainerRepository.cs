namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class TrainerRepository : BaseRepository<Trainer, Guid>, ITrainerRepository
    {
        public TrainerRepository(SportCenterDbContext DbContext) : base(DbContext)
        {

        }
    }
}
