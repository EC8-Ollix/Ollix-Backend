using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Users.Commands.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Users.Commands.ChangePassword
{
    public sealed record ChangePasswordCommand : IRequest<Result>
    {
        public UserInfo? UserInfo { get; set; }
        public Guid UserId { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
