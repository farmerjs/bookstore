using Book.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.Events
{
    public class EntityUpdated<T> : INotification where T : ParentEntity
    {
        public EntityUpdated(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; private set; }
    }
}
