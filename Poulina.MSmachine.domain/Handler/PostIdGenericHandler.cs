using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Command;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.IRepository;
using System.Threading;
using System.Threading.Tasks;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Handler
{
    public class PostIdGenericHandler<TEntity> : IRequestHandler<PostIDGenericCommand<TEntity>, TEntity> where TEntity : class
    {
        public IGenericRepository<TEntity> GenericRepository { get; set; }
        public PostIdGenericHandler(IGenericRepository<TEntity> genericRepository)
        {
            GenericRepository = genericRepository;
        }

        public Task<TEntity> Handle(PostIDGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = GenericRepository.AddId(request.Entity);
            return Task.FromResult(result);
        }
    }
}
