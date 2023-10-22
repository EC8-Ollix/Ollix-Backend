using Ardalis.Specification;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Extensions;

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
                Query.Search(c => c.CompanyName!, "%" + companyName + "%");

            if (!string.IsNullOrEmpty(bussinessName))
                Query.Search(c => c.BussinessName!, "%" + bussinessName + "%");

            if (!string.IsNullOrEmpty(cnpj))
                Query.Search(c => c.Cnpj!.Value!, "%" + cnpj.JustNumbers() + "%");

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
