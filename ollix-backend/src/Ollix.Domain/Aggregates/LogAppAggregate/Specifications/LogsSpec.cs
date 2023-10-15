using Ardalis.Specification;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Models;

namespace Ollix.Domain.Aggregates.LogAppAggregate.Specifications
{
    public class LogsSpec : Specification<LogApp, LogAppModel>
    {
        public LogsSpec(PaginationRequest paginationRequest, Guid clientId)
        {
            paginationRequest.NormalizePager();

            Query.Select(s => new LogAppModel(s));

            if (clientId != Guid.Empty)
                Query.Where(q => q.ClientId == clientId);

            Query
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize)
                .AsNoTracking(); 
        }

        public LogsSpec(Guid clientId)
        {
            if (clientId != Guid.Empty)
                Query.Where(q => q.ClientId == clientId);

            Query.AsNoTracking();
        }
    }
}
