using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ms_Machine.Domain.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        // Async Methods
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> condition = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);

        Task<IEnumerable<TEntity>> GetListByExpressionAsync(Expression<Func<TEntity, bool>> condition = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);

        Task<TEntity> GetByIdAsync(Guid id);

        TEntity AddId(TEntity entity);
        string Add(TEntity entity);
        string AddRange(IEnumerable<TEntity> entities);
        string Remove(Guid id);
        string RemoveRange(IEnumerable<TEntity> entites);
        TEntity GetByExpression(Expression<Func<TEntity, bool>> condition = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);

        IEnumerable<TEntity> GetListByExpression(Expression<Func<TEntity, bool>> condition = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);
        TEntity GetById(Guid id);



        string Update(TEntity entity);
    }
}
