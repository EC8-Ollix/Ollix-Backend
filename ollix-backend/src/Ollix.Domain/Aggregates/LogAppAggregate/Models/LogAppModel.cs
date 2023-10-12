using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.LogAppAggregate.Models
{
    public class LogAppModel
    {
        public Guid Id { get; set; }
        public string? Entity { get; set; }
        public string? Operation { get; set; }
        public Guid? EntityId { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string Date { get; set; }

        public LogAppModel(LogApp logApp)
        {
            Id = logApp.Id;
            Entity = logApp.Entity!.GetDescription();
            Operation = logApp.Operation!.GetDescription();
            EntityId = logApp.EntityId;
            UserId = logApp.UserId;
            UserName = logApp.UserApp!.FirstName + $" {logApp.UserApp.LastName}" ?? string.Empty;
            Date = logApp.Date.ToString("dd/MM/yyy HH:mm:ss");
        }
    }
}
