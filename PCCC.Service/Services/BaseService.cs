using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using PCCC.Repository.Interfaces;
using PCCC.Service.Interfaces;

namespace PCCC.Service.Services
{
    public class BaseService<T> : IServices<T> where T : class
    {
        private readonly IRepository<T> _baseReponsitory;

        public BaseService(IRepository<T> baseReponsitory)
        {
            _baseReponsitory = baseReponsitory;
        }


        #region Async

        public async Task<T> AddAsync(T entity)
        {
            return await _baseReponsitory.AddAsync(entity);
        }

        public async Task<bool> AddManyAsync(IEnumerable<T> entities)
        {
            return await _baseReponsitory.AddManyAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            await _baseReponsitory.DeleteAsync(entity);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await _baseReponsitory.GetAllAsync(predicate,orderBy,include);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await _baseReponsitory.GetFirstOrDefaultAsync(predicate, orderBy, include);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _baseReponsitory.UpdateAsync(entity);
        }




        #endregion



    }
}
