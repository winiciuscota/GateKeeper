using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GateKeeper.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        void Add(TEntity obj);
        void Remove(TEntity obj);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> orderingFunction);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> orderingFunction, int pageIndex, int pageSize);

        void AddRange(IEnumerable<TEntity> objs);

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}