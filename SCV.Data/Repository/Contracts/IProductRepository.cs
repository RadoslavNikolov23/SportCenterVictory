namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IProductRepository : IAsyncRepository<Product, Guid>, IRepository<Product, Guid>
    {
    }
}
