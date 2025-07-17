namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class EventRepository : BaseRepository<Event, int>, IEventRepository
    {
        public EventRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
