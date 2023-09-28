using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Abstractions
{
    public interface IClientAppEntity
    {
        public Guid ClientId { get; set; }
    }
}
