namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface ITrainerRepository : IAsyncRepository<Trainer, Guid>, IRepository<Trainer, Guid>
    {
    }
}
