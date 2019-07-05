using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ElectronicLibrary.DataAccessLayer.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElectronicLibrary.DataAccessLayer.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
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

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                return;

            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if(entity == null)
                return;
            _dbSet.Attach(entity);
            _dbSet.Update(entity);
        }
    }
}
