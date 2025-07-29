namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IMembershipUserRepository : IAsyncRepository<MembershipUser, (Guid, Guid)>, IRepository<MembershipUser, (Guid, Guid)>
    {

        MembershipUser? GetByCompositeKey(string membershipId, string userId);

        Task<MembershipUser?> GetByCompositeKeyAsync(string membershipId, string userId);

        bool Exists(string membershipId, string userId);

        Task<bool> ExistsAsync(string membershipId, string userId);
    }
}
