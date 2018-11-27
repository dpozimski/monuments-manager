using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class EntityNotFoundException<TEntity> : Exception where TEntity : BaseEntity
    {
        public EntityNotFoundException(int entityId) 
            : base($"Entity of type {typeof(TEntity).Name} with id {entityId} does not exists")
        { }

        public EntityNotFoundException(string entityFilter)
            : base($"Entity of type {typeof(TEntity).Name} does not exists with given criteria {entityFilter}")
        { }
    }
}
