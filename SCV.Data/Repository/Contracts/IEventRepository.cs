namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IEventRepository: IAsyncRepository<Event, Guid>, IRepository<Event, Guid>
    {
    }
}
