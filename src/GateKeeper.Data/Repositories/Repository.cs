using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GateKeeper.Data.Context;
using GateKeeper.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GateKeeper.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;


        public Repository(DbContext dbContext) => _dbContext = dbContext;

        public void Add(TEntity obj)
        {
            _dbContext.Set<TEntity>().Add(obj);
        }

        public void Remove(TEntity obj)
        {
            _dbContext.Set<TEntity>().Remove(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAllAsync(predicate, null);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> orderingFunction)
        {
            return await GetAllAsync(predicate, orderingFunction, 0, -1);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> orderingFunction, int pageIndex, int pageSize)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderingFunction != null)
            {
                query = query.OrderBy(orderingFunction);
            }

            if (pageSize != -1)
            {
                query = query.Skip(pageIndex * pageSize).Take(pageSize);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int objId)
        {
            return await _dbContext.Set<TEntity>().FindAsync(objId);
        }

        public TEntity Get(int objId)
        {
            return _dbContext.Set<TEntity>().Find(objId);
        }

        public void AddRange(IEnumerable<TEntity> objs)
        {
            _dbContext.AddRange(objs);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.CountAsync();
        }

    }
}