using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.ValueObjects;
using Ollix.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.LogAggregate
{
    public class LogApp : EntityBase
    {
        public EntityEnum? Entity { get; set; }
        public OperationEnum? Operation { get; set; }
        public Guid? EntityId { get; set; }
        public Guid ClientId { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset Date { get; set; }

        public UserApp? UserApp { get; set; }
        public ClientApp? ClientApp { get; set; }
    }
}
