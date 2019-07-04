using System.Linq.Expressions;

namespace DAL.RepositoryPattern.Interfaces
{
    using System;
    using System.Collections.Generic;
    public interface IRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
        void InsertOrUpdate(TEntity entity);
        void Delete(TEntity entity);

    }
}
