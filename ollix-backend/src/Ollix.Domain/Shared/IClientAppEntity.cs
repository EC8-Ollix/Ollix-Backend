using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Shared
{
    public interface IClientAppEntity
    {
        public Guid? ClientAppId { get; set; }
    }
}
