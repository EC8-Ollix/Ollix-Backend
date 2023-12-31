﻿using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.PropellerInfoAggregate
{
    public class PropellerInfoHistoric : EntityBase
    {
        public int AvarageRpm { get; private set; }
        public int Avaragekwh { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
        public Guid PropellerId { get; private set; }

        public Propeller? Propeller { get; set; }

        public PropellerInfoHistoric(Guid propellerId, int avarageRpm, int avaragekwh)
        {
            PropellerId = propellerId;

            AvarageRpm = avarageRpm;
            Avaragekwh = avaragekwh;

            UpdatedAt = DateTimeOffset.Now;
        }
    }
}
