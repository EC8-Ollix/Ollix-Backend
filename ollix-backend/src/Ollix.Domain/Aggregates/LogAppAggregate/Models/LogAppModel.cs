using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Domain.Aggregates.LogAppAggregate.Models
{
    public class LogAppModel
    {
        public Guid Id { get; set; }
        public string? Entity { get; set; }
        public string? Operation { get; set; }
        public Guid? EntityId { get; set; }
        public string? UserName { get; set; }
        public string Date { get; set; }

        public LogAppModel(LogApp logApp)
        {
            Id = logApp.Id;
            Entity = logApp.Entity!.GetDescription();
            Operation = logApp.Operation!.GetDescription();
            EntityId = logApp.EntityId;
            UserName = logApp.UserName;
            Date = logApp.Date.ToString("dd/MM/yyy HH:mm:ss");
        }
    }
}
