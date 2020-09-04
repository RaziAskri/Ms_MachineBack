using MediatR;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Command;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Handler
{
    public class PostGenericHandler<TEntity> : IRequestHandler<PostGenericCommand<TEntity>, string> where TEntity : class
    {

        public IGenericRepository<TEntity> GenericRepository { get; set; }
        public PostGenericHandler(IGenericRepository<TEntity> genericRepository)
        {
            GenericRepository = genericRepository;
        }


        public Task<string> Handle(PostGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = GenericRepository.Add(request.Entity);
            return Task.FromResult(result);
        }

    }
}
