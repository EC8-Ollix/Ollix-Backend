using Ardalis.Specification;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Domain.Aggregates.LogAppAggregate.Specifications
{
    public class LogsSpec : Specification<LogApp, LogAppModel>
    {
        public void WithBaseSpec(
                          Guid clientId,
                          EntityEnum? entity,
                          OperationEnum? operation,
                          string? userName,
                          DateTimeOffset[]? requestedDate)
        {

            Query.Select(s => new LogAppModel(s));

            if (clientId != Guid.Empty)
                Query.Where(q => q.ClientId == clientId);

            if (requestedDate is not null && requestedDate.Any())
                Query.Where(u =>
                    u.Date.Date >= requestedDate.First().Date &&
                    u.Date.Date <= requestedDate.Last().Date
                );

            if (!string.IsNullOrEmpty(userName))
                Query.Search(u => u.UserName!, "%" + userName.ToTrim() + "%");
            
            if (entity != 0)
                Query.Where(u => u.Entity == entity);

            if (operation != 0)
                Query.Where(u => u.Operation == operation);

            Query.AsNoTracking();
        }

        public void WithPagination(PaginationRequest paginationRequest)
        {
            paginationRequest.NormalizePager();
            Query
                .OrderByDescending(o => o.Date)
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }
    }
}
