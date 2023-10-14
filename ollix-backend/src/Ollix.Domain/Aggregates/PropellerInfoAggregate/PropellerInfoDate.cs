using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.PropellerInfoAggregate
{
    public class PropellerInfoDate : EntityBase
    {
        public int TotalRpm { get; private set; }
        public int TotalKwh { get; private set; }
        public int ReadingCount { get; private set; }
        public DateTimeOffset InfoDate { get; private set; }
        public Guid PropellerId { get; private set; }

        public Propeller? Propeller { get; set; }

        public PropellerInfoDate() { }

        public PropellerInfoDate(Guid propellerId, int rpm, int kwh)
        {
            PropellerId = propellerId;

            TotalRpm = rpm;
            TotalKwh = kwh;
            ReadingCount = 1;

            InfoDate = DateTimeOffset.UtcNow;
        }

        public void UpdateInfoData(int newRpm, int newKwh)
        {
            if (DateTimeOffset.UtcNow.Date != InfoDate.Date)
                return;

            TotalRpm += newRpm;
            TotalKwh += newKwh;

            ReadingCount++;
        }

        public double GetAverageRpm()
        {
            if (ReadingCount == 0) return 0;
            return (double)TotalRpm / ReadingCount;
        }
    }
}
