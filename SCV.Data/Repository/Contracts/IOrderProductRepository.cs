namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IOrderProductRepository : IAsyncRepository<OrderProduct, (Guid, Guid)>, IRepository<OrderProduct, (Guid, Guid)>
    {

        OrderProduct? GetByCompositeKey(string orderId, string productId);

        Task<OrderProduct?> GetByCompositeKeyAsync(string orderId, string productId);

        bool Exists(string orderId, string productId);

        Task<bool> ExistsAsync(string orderId, string productId);
    }
}
