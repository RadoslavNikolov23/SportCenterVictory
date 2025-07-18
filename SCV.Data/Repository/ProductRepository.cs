namespace SCV.Data.Repository
{
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }
    }
}
