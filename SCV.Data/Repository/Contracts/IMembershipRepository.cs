namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IMembershipRepository : IAsyncRepository<Membership, int>, IRepository<Membership, int>
    {

    }
}
