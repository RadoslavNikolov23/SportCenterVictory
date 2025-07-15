namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class MembershipRepository : BaseRepository<Membership, int>, IMembershipRepository
    {
        public MembershipRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
