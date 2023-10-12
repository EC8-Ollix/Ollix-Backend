using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.ClientAppAggregate.Specifications;
using Ollix.Domain.ValueObjects;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Clients.Commands.CreateClient
{
    internal sealed class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<ClientApp>>
    {
        private readonly IRepository<ClientApp> _repository;

        public CreateClientCommandHandler(IRepository<ClientApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<ClientApp>> Handle(CreateClientCommand request, 
            CancellationToken cancellationToken)
        {
            var cnpj = new CNPJ(request.Cnpj!);

            var company = await _repository
                .FirstOrDefaultAsync(new ClientByCnpjSpec(cnpj), cancellationToken);

            if (company is not null)
                return Result.Error("CNPJ da empresa já está cadastrado na plataforma");

            var client = new ClientApp(request.CompanyName!, request.BussinessName!, cnpj);

            await _repository.AddAsync(client, cancellationToken);

            return Result.Success(client);
        }
    }
}
