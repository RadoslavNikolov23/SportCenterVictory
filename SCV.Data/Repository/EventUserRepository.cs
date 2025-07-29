namespace SCV.Data.Repository
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class EventUserRepository : BaseRepository<EventUser, (Guid, Guid)>, IEventUserRepository
    {
        public EventUserRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }


        public Task<EventUser?> GetByCompositeKeyAsync(string eventId, string userId)
        {
            return this.GetAllAttached()
                        .SingleOrDefaultAsync(eu => eu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        eu.EventId.ToString().ToLower() == eventId.ToLower());
        }

        public Task<bool> ExistsAsync(string eventId, string userId)
        {
            return this.GetAllAttached()
                .AnyAsync(eu => eu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                            eu.EventId.ToString().ToLower() == eventId.ToLower());
        }

        public EventUser? GetByCompositeKey(string eventId, string userId)
        {
            return this.GetAllAttached()
                .SingleOrDefault(eu => eu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        eu.EventId.ToString().ToLower() == eventId.ToLower());
        }

        public bool Exists(string eventId, string userId)
        {
            return this.GetAllAttached()
                .Any(eu => eu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                            eu.EventId.ToString().ToLower() == eventId.ToLower());
        }

    }
}
