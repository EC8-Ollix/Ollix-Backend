using MediatR;

namespace Ollix.SharedKernel;

public class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}

