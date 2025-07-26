namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class CrossfitClassRepository : BaseRepository<CrossfitClass, Guid>, ICrossfitClassRepository
    {
        public CrossfitClassRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
