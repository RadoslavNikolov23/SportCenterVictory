namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IOrderRepository : IAsyncRepository<Order, Guid>, IRepository<Order, Guid>
    {
    }
}
