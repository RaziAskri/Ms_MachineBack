using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Command
{
    public class PostIDGenericCommand<TEntity> : IRequest<TEntity> where TEntity : class
    {

        public TEntity Entity { get; }
        public PostIDGenericCommand(TEntity entity)
        {
            Entity = entity;
        }

    }
}
