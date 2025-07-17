namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IEventRepository: IAsyncRepository<Event, int>, IRepository<Event, int>
    {
    }
}
