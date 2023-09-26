using Ardalis.Result;
using MediatR;

namespace Ollix.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : 
    IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}

