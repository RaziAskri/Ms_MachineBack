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
    public class GetByIdGenericHandler<TEntity> : IRequestHandler<GetByIdGenericQuery<TEntity>, TEntity> where TEntity : class
    {

        private readonly IGenericRepository<TEntity> Repository;
        public GetByIdGenericHandler(IGenericRepository<TEntity> repository)
        {
            Repository = repository;
        }


        public Task<TEntity> Handle(GetByIdGenericQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.GetByExpression(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }
}
