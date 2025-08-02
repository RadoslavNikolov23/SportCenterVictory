namespace SCV.Data.Repository.Contracts
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        int Count();

        TEntity? GetById(TKey id);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetAllAttached();

        TEntity? SingleOrDefault(Func<TEntity, bool> predicate);

        TEntity? FirstOrDefault(Func<TEntity, bool> predicate);

        void Add(TEntity item);

        void AddRange(IEnumerable<TEntity> items);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

        bool HardDelete(TEntity entity);

        void HardDeleteRange(IEnumerable<TEntity> entities);

        void SaveChanges();
    }
}
