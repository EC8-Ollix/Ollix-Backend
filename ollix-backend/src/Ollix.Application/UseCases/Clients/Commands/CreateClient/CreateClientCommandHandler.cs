using Ardalis.Result;
using Ollix.Application.Abstractions;
using Ollix.Domain.ClientAppAggregate;
using Ollix.Domain.ClientAppAggregate.Specifications;
using Ollix.Domain.UserAggregate;
using Ollix.Domain.UserAppAggregate.Specifications;
using Ollix.Domain.ValueObjects;
using Ollix.SharedKernel;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.Authentication.Commands.Register
{
    internal sealed class CreateClientCommandHandler : ICommandHandler<CreateClientCommand, ClientApp>
    {
        private readonly IRepository<ClientApp> _repository;

        public CreateClientCommandHandler(IRepository<ClientApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<ClientApp>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var cnpj = new CNPJ(request.Cnpj!);

            var company = await _repository
                .FirstOrDefaultAsync(new GetCompanyByCnpjSpec(cnpj), cancellationToken);

            if (company is not null)
                return Result.Error("CNPJ da empresa já está cadastrado na plataforma");

            var client = new ClientApp()
            {
                CompanyName = request.CompanyName,
                BussinessName = request.BussinessName,
                Cnpj = cnpj,
            };

            await _repository.AddAsync(client, cancellationToken);

            return Result.Success(client);
        }
    }
}
