namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IMembershipRepository : IAsyncRepository<Membership, Guid>, IRepository<Membership, Guid>
    {

    }
}
