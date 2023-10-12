using Ardalis.Specification;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Models;

namespace Ollix.Domain.Aggregates.LogAppAggregate.Specifications
{
    public class LogsSpec : Specification<LogApp, LogAppModel>
    {
        public LogsSpec(PaginationRequest paginationRequest, ClientApp clientApp)
        {
            paginationRequest.NormalizePager();

            Query
                .Select(s => new LogAppModel(s))
                .Where(q => q.ClientId == clientApp.Id)
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }

        public LogsSpec(ClientApp clientApp)
        {
            Query.Where(q => q.ClientId == clientApp.Id);
        }
    }
}
