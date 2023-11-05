using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.SharedKernel;

namespace Ollix.Domain.Events
{
    public class EntityControlEvent : DomainEventBase
    {
        public EntityControlEvent(UserInfo userInfo, EntityEnum entityType, OperationEnum operation, EntityBase entity, string identifier)
        {
            LogApp = new LogApp
            {
                Identifier = identifier,
                Entity = entityType,
                Operation = operation,
                EntityId = entity.Id,
                UserName = userInfo.FirstName + (!string.IsNullOrEmpty(userInfo.LastName) ? $" {userInfo.LastName}" : string.Empty),
                ClientId = userInfo.ClientApp!.Id
            };
        }

        public LogApp LogApp { get; private set; }
    }
}
