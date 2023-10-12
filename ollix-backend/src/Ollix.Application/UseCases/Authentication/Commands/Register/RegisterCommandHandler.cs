using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.SharedKernel.Extensions;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Authentication.Commands.Register
{
    internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<UserInfo>>
    {
        private readonly IRepository<UserApp> _repository;
        private readonly IMediator _mediator;
        public RegisterCommandHandler(IRepository<UserApp> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Result<UserInfo>> Handle(RegisterCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await _repository
                .FirstOrDefaultAsync(new UserAppByEmailSpec(request.UserEmail!), cancellationToken);

            if (user is not null)
                return Result.Error("Email já cadastrado na plataforma");

            var clientCreated = await _mediator.Send(request.CreateClientCommand!, cancellationToken);

            if (!clientCreated.IsSuccess)
                return Result.Error(clientCreated.Errors.FirstOrDefault() ?? string.Empty);

            user = new UserApp(
                request.FirstName!,
                request.LastName!,
                UserType.Client,
                request.UserEmail!.ToLower()!,
                request.UserPassword!.ToHash(),
                clientCreated.Value.Id);

            await _repository.AddAsync(user, cancellationToken);

            return Result.Success(new UserInfo(user, clientCreated.Value));
        }
    }
}
