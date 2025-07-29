namespace SCV.Data.Repository
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class CrossfitClassUserRepository : BaseRepository<CrossfitClassUser, (Guid, Guid)>, ICrossfitClassUserRepository
    {
        public CrossfitClassUserRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }

        public Task<CrossfitClassUser?> GetByCompositeKeyAsync(string crossfitClasId, string userId)
        {
            return this.GetAllAttached()
                        .SingleOrDefaultAsync(ccu => ccu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        ccu.CrossfitClassId.ToString().ToLower() == crossfitClasId.ToLower());
        }

        public Task<bool> ExistsAsync(string crossfitClasId, string userId)
        {
            return this.GetAllAttached()
                .AnyAsync(ccu => ccu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                            ccu.CrossfitClassId.ToString().ToLower() == crossfitClasId.ToLower());
        }

        public CrossfitClassUser? GetByCompositeKey(string crossfitClasId, string userId)
        {
            return this.GetAllAttached()
                .SingleOrDefault(ccu => ccu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        ccu.CrossfitClassId.ToString().ToLower() == crossfitClasId.ToLower());
        }

        public bool Exists(string crossfitClasId, string userId)
        {
            return this.GetAllAttached()
                .Any(ccu => ccu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                            ccu.CrossfitClassId.ToString().ToLower() == crossfitClasId.ToLower());
        }

    }
}
