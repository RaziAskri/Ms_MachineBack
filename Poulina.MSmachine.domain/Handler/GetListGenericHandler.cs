using MediatR;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.IRepository;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Queries;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Handler
{
    public class GetListGenericHandler<TEntity> : IRequestHandler<GetListGenericQuery<TEntity>, IEnumerable<TEntity>> where TEntity : class
    {

        private readonly IGenericRepository<TEntity> Repository;
        public GetListGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }


        public Task<IEnumerable<TEntity>> Handle(GetListGenericQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.GetListByExpression(request.Condition, request.Includes);
            return Task.FromResult(result);
        }

    }
}
