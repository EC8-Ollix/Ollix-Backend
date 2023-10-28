using Ardalis.Specification;
using Newtonsoft.Json.Linq;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Extensions;
using System.IO;

namespace Ollix.Domain.Aggregates.ClientAppAggregate.Specifications
{
    public class ClientsSpec : Specification<ClientApp>
    {
        public void WithBaseSpec(string? companyName,
                           string? bussinessName,
                           string? cnpj,
                           bool? active)
        {
            if (!string.IsNullOrEmpty(companyName))
                Query.Where(u => u.CompanyName!.Contains(companyName.ToTrim()));

            if (!string.IsNullOrEmpty(bussinessName))
                Query.Where(u => u.BussinessName!.Contains(bussinessName.ToTrim()));

            if (!string.IsNullOrEmpty(cnpj))
                Query.Where(u => u.Cnpj!.Value!.Contains(cnpj.ToTrim()));

            if (active.HasValue)
                Query.Where(c => c.Active == active.Value);

            Query.AsNoTracking();
        }

        public void WithPagination(PaginationRequest paginationRequest)
        {
            paginationRequest.NormalizePager();

            Query
                .OrderBy(c => c.BussinessName)
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }

        public ClientsSpec() { }
    }
}
