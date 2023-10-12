using MediatR;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Clients.Events
{
    public class EntityUpdatedEventHandler : INotificationHandler<EntityUpdatedEvent>
    {
        private readonly IRepository<LogApp> _repository;
        private readonly IRepository<UserApp> _userApprepository;

        public EntityUpdatedEventHandler(IRepository<LogApp> repository,
            IRepository<UserApp> userApprepository)
        {
            _repository = repository;
            _userApprepository = userApprepository;
        }

        public async Task Handle(EntityUpdatedEvent notification, 
            CancellationToken cancellationToken)
        {
            var logApp = notification.LogApp;
            var user = await _userApprepository.GetByIdAsync(logApp.UserId, cancellationToken);
            if (user is null) 
                return;

            logApp.Date = DateTimeOffset.Now;
            logApp.ClientId = user!.ClientId;

            await _repository.AddAsync(logApp, cancellationToken);   
        }
    }
}
