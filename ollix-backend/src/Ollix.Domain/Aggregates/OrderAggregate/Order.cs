using Ollix.Domain.Abstractions;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.PropellerInfoAggregate;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.OrderAggregate
{
    public class Order : EntityBase, IClientAppEntity
    {
        public string? RequesterName { get; private set; }
        public string? RequesterEmail { get; private set; }
        public string? Observation { get; private set; }
        public DateTimeOffset RequestDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public DateTimeOffset? InstallationDate { get; private set; }
        public int QuantityRequested { get; private set; }
        public Guid AddressId { get; private set; }
        public Guid ClientId { get; private set; }

        public AddressApp? AddressApp { get; set; }
        public ClientApp? ClientApp { get; set; }

        public ICollection<Propeller>? Propellers { get; } = new List<Propeller>();

        public Order() { }

        public Order(
            string requesterName,
            string requesterEmail,
            string? observation,
            DateTimeOffset requestDate,
            OrderStatus orderStatus,
            int quantityRequested,
            AddressApp address,
            Guid clientId)
        {
            RequesterName = requesterName;
            RequesterEmail = requesterEmail;
            Observation = observation;
            RequestDate = requestDate;
            OrderStatus = orderStatus;
            QuantityRequested = quantityRequested;
            AddressId = address.Id;
            ClientId = clientId;

            AddressApp = address;
            InstallationDate = null;
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
            if (OrderStatus is OrderStatus.Completed)
                InstallationDate = DateTimeOffset.Now;
        }

        public void ScheduleInstallation(DateTimeOffset installationDate)
        {
            OrderStatus = OrderStatus.InstallationPending;
            InstallationDate = installationDate.Date;
        }

        public bool CanCancel()
        {
            return this.OrderStatus == OrderStatus.Pending;
        }

        public bool CanConfirmInstallation()
        {
            return this.OrderStatus == OrderStatus.InstallationPending;
        }
    }
}
