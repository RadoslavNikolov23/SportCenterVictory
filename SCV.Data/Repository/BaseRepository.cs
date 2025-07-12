namespace SCV.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Repository.Contracts;

    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>, IAsyncRepository<TEntity, TKey>
        where TEntity : class
    {
        protected SportCenterDbContext DbContext;

        protected DbSet<TEntity> DbSet;

        public BaseRepository(SportCenterDbContext DbContext)
        {
            this.DbContext = DbContext;
            this.DbSet = this.DbContext.Set<TEntity>();
        }

        //---------------- Asynchronous Methods ----------------
        public async Task<int> CountAsync()
        {
            int result = 0;

            try
            {
                result = await DbSet.CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while counting entities, the message is {ex.Message} ");
            }

            return result;
        }

        public async Task<TEntity?>? GetByIdAsync(TKey id)
        {
            TEntity? entity = null;

            try
            {
                entity = await DbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity by ID, the message is {ex.Message}");
            }

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = new List<TEntity>();

            try
            {
                entities = await this.DbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving all entities, the message is {ex.Message}");
            }

            return entities;
        }

        public async Task<TEntity?>? SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? entity = null;

            try
            {
                entity = await DbSet.SingleOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving a single entity, the message is {ex.Message}");
            }

            return entity;
        }

        public async Task<TEntity?>? FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? entity = null;

            try
            {
                entity = await DbSet.FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the first entity, the message is {ex.Message}");
            }

            return entity;
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity cannot be null.");
            }

            try
            {
                await DbSet.AddAsync(entity);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding the entity, the message is {ex.Message}");
            }
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if(entities == null || entities.Count()==0)
            {
                throw new ArgumentNullException(nameof(entities), "The entities collection cannot be null or empty.");
            }

            try
            {
                await this.DbSet.AddRangeAsync(entities);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding the entities, the message is {ex.Message}");
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            int result = 0;

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity cannot be null.");
            }

            try
            {
                DbSet.Update(entity);
                result = await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the entity, the message is {ex.Message}");
            }

            return result>0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            int result = 0;
            this.PerformSoftDeleteOfEntity(entity);

            this.DbSet.Update(entity);
            result = await this.DbContext.SaveChangesAsync();

            return result>0;
        }

        public async Task<bool> HardDeleteAsync(TEntity entity)
        {
            int result = 0;

            this.DbSet.Remove(entity);
            result = await this.DbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task SaveChangesAsync()
        {
            await this.DbContext.SaveChangesAsync();
        }
      
        //---------------- Synchronous Methods ----------------
        public int Count()
        {
            int result = 0;

            try
            {
                result = DbSet.Count();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while counting entities, the message is {ex.Message} ");
            }

            return result;
        }

        public TEntity? GetById(TKey id)
        {
            TEntity? entity = null;

            try
            {
                entity = DbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity by ID, the message is {ex.Message}");
            }

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> entities = new List<TEntity>();

            try
            {
                entities = this.DbSet.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving all entities, the message is {ex.Message}");
            }

            return entities;
        }

        public IQueryable<TEntity> GetAllAttached()
        {
            return this.DbSet.AsQueryable();
        }

        public TEntity? SingleOrDefault(Func<TEntity, bool> predicate)
        {
            TEntity? entity = null;

            try
            {
                entity = this.DbSet.SingleOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving a single entity, the message is {ex.Message}");
            }

            return entity;
        }

        public TEntity? FirstOrDefault(Func<TEntity, bool> predicate)
        {
            TEntity? entity = null;

            try
            {
                entity = this.DbSet.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the first entity, the message is {ex.Message}");
            }

            return entity;
        }

        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "The entity cannot be null.");
            }

            try
            {
                this.DbSet.Add(item);
                this.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding the entity, the message is {ex.Message}");
            }
        }

        public void AddRange(IEnumerable<TEntity> items)
        {
            if(items == null || items.Count()==0)
            {
                throw new ArgumentNullException(nameof(items), "The entities collection cannot be null or empty.");
            }

            try
            {
                this.DbSet.AddRange(items);
                this.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding the entities, the message is {ex.Message}");
            }
        }

        public bool Update(TEntity entity)
        {
            int result = 0;

            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity cannot be null.");
            }

            try
            {
                this.DbSet.Update(entity);
                result = this.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the entity, the message is {ex.Message}");
            }

            return result > 0;
        }

        public bool Delete(TEntity entity)
        {
            this.PerformSoftDeleteOfEntity(entity);

            int result = 0;

            this.DbSet.Update(entity);
            result = this.DbContext.SaveChanges();

            return result > 0;
        }

        public bool HardDelete(TEntity entity)
        {
            int result = 0;

            this.DbSet.Remove(entity);
            result = this.DbContext.SaveChanges();

            return result > 0;
        }

        public void SaveChanges()
        {
            this.DbContext.SaveChanges();
        }

        private void PerformSoftDeleteOfEntity(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity cannot be null.");
            }

            try
            {
                PropertyInfo? property = entity.GetType().GetProperty("IsDeleted");

                if (property != null && property.CanWrite)
                {
                    property.SetValue(entity, true);
                }
                else
                {
                    throw new InvalidOperationException("The entity does not support soft deletion.");

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while performing soft delete, the message is {ex.Message}");
            }
        }
    }
}
