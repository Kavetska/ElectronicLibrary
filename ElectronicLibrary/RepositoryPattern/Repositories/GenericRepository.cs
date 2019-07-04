using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.RepositoryPattern.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void InsertOrUpdate(TEntity entity)
        {
            dbSet.Attach(entity);

            // These entities will also begin to be tracked by the context. If a reachable
            // entity has its primary key value set then it will be tracked in the Modified state. 
            // If the primary key value is not set then it will be tracked in the Added state. 
            // An entity is considered to have its primary key value set if the primary key 
            // property is set to anything other than the CLR default for the property type.
            dbSet.Update(entity);
        }
    }
}
