using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Data;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Poulina.ProjectManagmentMS.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {


        protected readonly PoulinaDbContext _context;

        public GenericRepository(PoulinaDbContext context)
        {
            _context = context;
        }
        public TEntity AddId(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;

        }

        public string Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return "Add Done";
        }

        public async Task AddAsync(TEntity entity)
        {

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public string AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<IEnumerable<TEntity>>().AddRange(entities);
            _context.SaveChanges();
            return "AddRange Done";
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<IEnumerable<TEntity>>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public TEntity GetByExpression(Expression<Func<TEntity, bool>> condition = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
            {
                query = includes(query);
            }
            if (condition != null)
            {
                return query.FirstOrDefault(condition);
            }
            return query.FirstOrDefault();
        }

        public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> condition = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
            {
                query = includes(query);
            }
            if (condition != null)
            {
                return await query.FirstOrDefaultAsync(condition);
            }
            return await query.FirstOrDefaultAsync();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);

        }

        public IEnumerable<TEntity> GetListByExpression(Expression<Func<TEntity, bool>> condition = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
            {
                query = includes(query);
            }
            if (condition != null)
            {
                return query.Where(condition).ToList();
            }
            return query.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetListByExpressionAsync(Expression<Func<TEntity, bool>> condition = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
            {
                query = includes(query);
            }
            if (condition != null)
            {
                return await query.Where(condition).ToListAsync();
            }
            return await query.ToListAsync();
        }



        public string Remove(Guid id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            return "Remove Done";
        }

        public string RemoveRange(IEnumerable<TEntity> entites)
        {
            _context.Set<TEntity>().RemoveRange(entites);
            _context.SaveChanges();
            return "RemoveRange Done";
        }

        public string Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return "Update Done";
        }
    }
}
