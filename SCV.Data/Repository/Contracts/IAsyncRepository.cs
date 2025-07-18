namespace SCV.Data.Repository.Contracts
{
    using System.Linq.Expressions;

    public interface IAsyncRepository<TEntity,TKey> where TEntity : class
    {
        Task<int> CountAsync();

        Task<TEntity?> GetByIdAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?>? SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?>? FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        Task<bool> HardDeleteAsync(TEntity entity);

        Task SaveChangesAsync();
    }
}
