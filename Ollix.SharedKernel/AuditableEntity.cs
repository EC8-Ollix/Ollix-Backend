using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.SharedKernel
{
    public abstract class AuditableEntity
    {
        public Guid UserId { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset LastUpdatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public AuditableEntity(Guid userId)
        {
            CreatedAt = DateTimeOffset.UtcNow;
            LastUpdatedAt = DateTimeOffset.UtcNow;
            IsDeleted = false;
            UserId = userId;
        }

        public void MarkAsUpdated()
        {
            LastUpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
