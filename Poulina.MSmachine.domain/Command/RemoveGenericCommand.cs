using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Command
{
    public class RemoveGenericCommand<TEntity> : IRequest<string> where TEntity : class
    {
        public Guid id;

        public TEntity Entity { get; }
        public RemoveGenericCommand(TEntity entity)
        {
            Entity = entity;
        }

        public RemoveGenericCommand(Guid id)
        {
            this.id = id;
        }
    }
}
