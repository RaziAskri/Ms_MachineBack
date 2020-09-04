using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Queries
{
    public class GetByIdGenericQuery<TEntity> : IRequest<TEntity> where TEntity : class
    {

        public Expression<Func<TEntity, bool>> Condition { get; set; }
        public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; set; }

        public GetByIdGenericQuery(Expression<Func<TEntity, bool>> condition = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            Condition = condition;
            Includes = includes;
        }


    }
}
