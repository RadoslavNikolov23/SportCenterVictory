namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface ICrossfitClassRepository : IAsyncRepository<CrossfitClass, int>, IRepository<CrossfitClass, int>
    {
    }
}
