using MediatR;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Events
{
    public class EntityUpdatedEvent : DomainEventBase
    {
        public EntityUpdatedEvent(Guid userId, EntityEnum entityType, object entity)
        {
            LogApp = new LogApp
            {
                Entity = entityType,
                Operation = OperationEnum.Update,
                UserId = userId,
                EntityId = ((EntityBase)entity).Id
            };
        }
        public LogApp LogApp { get; private set; }
    }
}
