using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.AddressAppAggregate.Specifications;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Infrastructure.Integrations.ViaCep;
using Ollix.SharedKernel.Extensions;
using Ollix.SharedKernel.Interfaces;
using System.Net.Http.Json;

namespace Ollix.Application.UseCases.Orders.Commands.CreateOrder
{
    internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Order>>
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<AddressApp> _addressRepository;
        private readonly IHttpClientFactory _clientFactory;
        public CreateOrderCommandHandler(IRepository<Order> repository,
            IRepository<AddressApp> adressRepository, IHttpClientFactory clientFactory)
        {
            _repository = repository;
            _addressRepository = adressRepository;
            _clientFactory = clientFactory;
        }

        public async Task<Result<Order>> Handle(CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var address = await _addressRepository.FirstOrDefaultAsync(new AdressByPostalCode(request.PostalCode!), cancellationToken);
            if (address is null)
            {
                var createAdressResult = await CreateAddress(request.PostalCode, cancellationToken);
                if (!createAdressResult.IsSuccess)
                    return Result.Error(createAdressResult.Errors.ToArray());

                address = createAdressResult.Value;
            }

            var order = new Order(
                request.RequesterName!,
                request.RequesterEmail!,
                request.Observation,
                DateTimeOffset.UtcNow,
                OrderStatus.Pending,
                request.QuantityRequested,
                address!,
                request.UserInfo!.ClientApp!.Id);

            await _repository.AddAsync(order, cancellationToken);

            return Result.Success(order);
        }

        private async Task<Result<AddressApp>> CreateAddress(string? postalCode, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient(nameof(ViaCepClient));

            var response = await httpClient.GetAsync(ViaCepClient.GetPostalCodeUrl(postalCode!), cancellationToken);
            if (!response.IsSuccessStatusCode)
                return Result.Error("Erro ao buscar as informações do CEP");

            var cepModel = await response.Content.ReadFromJsonAsync<ViaCepModelResponse>(cancellationToken: cancellationToken);
            if (cepModel is null)
                return Result.Error("Erro ao buscar as informações do CEP");

            var address = new AddressApp(
                cepModel.Cep.JustNumbers(),
                cepModel.Logradouro,
                cepModel.Bairro,
                cepModel.Localidade,
                cepModel.Uf);

            await _addressRepository.AddAsync(address, cancellationToken);

            return Result.Success(address);
        }
    }
}
