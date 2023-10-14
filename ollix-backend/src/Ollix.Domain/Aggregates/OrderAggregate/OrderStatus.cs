using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.OrderAggregate
{
    public enum OrderStatus
    {
        Pending = 1,
        Approved = 2,
        Denied = 3
    }
}
