using Ardalis.Specification;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.LogAppAggregate.Specifications
{
    public class LogsSpec : Specification<LogApp, LogAppModel>
    {
        public LogsSpec(PaginationRequest paginationRequest, ClientApp clientApp)
        {
            paginationRequest.NormalizePager();

            Query
                .Select(s => new LogAppModel(s))
                .Include(i => i.UserApp)
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
