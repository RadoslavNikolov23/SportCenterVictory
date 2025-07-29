namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IEventUserRepository : IAsyncRepository<EventUser, (Guid, Guid)>, IRepository<EventUser, (Guid, Guid)>
    {

        EventUser? GetByCompositeKey(string eventId, string userId);

        Task<EventUser?> GetByCompositeKeyAsync(string eventId, string userId);

        bool Exists(string eventId, string userId);

        Task<bool> ExistsAsync(string eventId, string userId);
    }
}
