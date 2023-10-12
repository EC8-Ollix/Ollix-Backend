using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.Events
{
    public class EntityControlEventHandler : INotificationHandler<EntityControlEvent>
    {
        private readonly IRepository<LogApp> _repository;

        public EntityControlEventHandler(IRepository<LogApp> repository)
        {
            _repository = repository;
        }

        public async Task Handle(EntityControlEvent notification,
            CancellationToken cancellationToken)
        {
            var logApp = notification.LogApp;

            logApp.Date = DateTimeOffset.Now;

            await _repository.AddAsync(logApp, cancellationToken);
        }
    }
}
