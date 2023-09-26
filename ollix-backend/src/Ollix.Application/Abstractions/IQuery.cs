using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.Abstractions;

public interface IQuery<TResponse>: IRequest<Result<TResponse>>
{
}

