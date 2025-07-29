namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface ICrossfitClassUserRepository : IAsyncRepository<CrossfitClassUser, (Guid, Guid)>, IRepository<CrossfitClassUser, (Guid, Guid)>
    {

        CrossfitClassUser? GetByCompositeKey(string crossfitClassId, string userId);

        Task<CrossfitClassUser?> GetByCompositeKeyAsync(string crossfitClassId, string userId);

        bool Exists(string crossfitClassId, string userId);

        Task<bool> ExistsAsync(string crossfitClassId, string userId);
    }
}
