namespace SCV.Data.Repository
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class MembershipUserRepository : BaseRepository<MembershipUser, (Guid, Guid)>, IMembershipUserRepository
    {
        public MembershipUserRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }


        public Task<MembershipUser?> GetByCompositeKeyAsync(string membershipId, string userId)
        {
            return this.GetAllAttached()
                        .SingleOrDefaultAsync(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        mu.MembershipId.ToString().ToLower() == membershipId.ToLower());
        }

        public Task<bool> ExistsAsync(string membershipId, string userId)
        {
            return this.GetAllAttached()
                .AnyAsync(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower() 
                       && mu.MembershipId.ToString().ToLower() == membershipId.ToLower());
        }

        public MembershipUser? GetByCompositeKey(string membershipId, string userId)
        {
            return this.GetAllAttached()
                .SingleOrDefault(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower() && mu.MembershipId.ToString().ToLower() == membershipId.ToLower());
        }

        public bool Exists(string membershipId, string userId)
        {
            return this.GetAllAttached()
                .Any(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower() 
                        && mu.MembershipId.ToString().ToLower() == membershipId.ToLower());
        }

    }
}
