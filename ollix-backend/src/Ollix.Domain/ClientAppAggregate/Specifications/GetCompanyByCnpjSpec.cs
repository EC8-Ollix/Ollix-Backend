using Ardalis.Specification;
using Ollix.Domain.UserAggregate;
using Ollix.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.ClientAppAggregate.Specifications
{
    public class GetCompanyByCnpjSpec : SingleResultSpecification<ClientApp>
    {
        public GetCompanyByCnpjSpec(CNPJ cnpj)
        {
            Query.Where(u => u.Cnpj!.Value == cnpj.Value);
        }
    }
}
