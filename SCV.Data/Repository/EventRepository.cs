namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class EventRepository : BaseRepository<Event, Guid>, IEventRepository
    {
        public EventRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
