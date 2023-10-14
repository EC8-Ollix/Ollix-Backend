using Ollix.Domain.Abstractions;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.OrderAggregate
{
    public class Order : EntityBase, IClientAppEntity
    {
        public string? RequesterName { get; private set; }
        public string? RequesterEmail { get; private set; }
        public string? Observation { get; private set; }
        public DateTimeOffset RequestDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public int QuantityRequested { get; private set; }
        public Guid AddressId { get; private set; }
        public Guid PropellerId { get; private set; }
        public Guid ClientId { get; private set; }

        public AddressApp? AddressApp { get; set; }
        public Propeller? Propeller { get; set; }
        public ClientApp? ClientApp { get; set; }

        public Order() { }

        public Order(
            string requesterName,
            string requesterEmail,
            string observation,
            DateTimeOffset requestDate,
            OrderStatus orderStatus,
            int quantityRequested,
            Guid addressId,
            Guid clientId)
        {
            RequesterName = requesterName;
            RequesterEmail = requesterEmail;
            Observation = observation;
            RequestDate = requestDate;
            OrderStatus = orderStatus;
            QuantityRequested = quantityRequested;
            AddressId = addressId;
            ClientId = clientId;
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }

        public void SetHeliceId(Guid propellerId)
        {
            PropellerId = propellerId;
        }
    }
}
