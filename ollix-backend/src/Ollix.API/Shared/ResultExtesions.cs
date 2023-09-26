using Ardalis.Result;

namespace Ollix.API.Shared;

public static class ResultExtensions
{
    public static ResultHandler<T> Handle<T>(this Result<T> result)
    {
        return new ResultHandler<T>(result);
    }
}

