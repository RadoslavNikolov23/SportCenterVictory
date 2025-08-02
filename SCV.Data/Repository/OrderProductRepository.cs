namespace SCV.Data.Repository
{
    using Microsoft.EntityFrameworkCore;

    using System.Threading.Tasks;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class OrderProductRepository : BaseRepository<OrderProduct, (Guid, Guid)>, IOrderProductRepository
    {
        public OrderProductRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }

        public Task<OrderProduct?> GetByCompositeKeyAsync(string orderId, string productId)
        {
            return this.GetAllAttached()
                .SingleOrDefaultAsync(op => op.OrderId.ToString().ToLower() == orderId.ToLower()
                        && op.ProductId.ToString().ToLower() == productId.ToLower());
        }

        public Task<bool> ExistsAsync(string orderId, string productId)
        {
            return this.GetAllAttached()
                .AnyAsync(op => op.OrderId.ToString().ToLower() == orderId.ToLower()
                        && op.ProductId.ToString().ToLower() == productId.ToLower());
        }

        public OrderProduct? GetByCompositeKey(string orderId, string productId)
        {
            return this.GetAllAttached()
                .SingleOrDefault(op => op.OrderId.ToString().ToLower() == orderId.ToLower()
                     && op.ProductId.ToString().ToLower() == productId.ToLower());
        }

        public bool Exists(string orderId, string productId)
        {
            return this.GetAllAttached()
                .Any(op => op.OrderId.ToString().ToLower() == orderId.ToLower()
                        && op.ProductId.ToString().ToLower() == productId.ToLower());
        }


    }
}
