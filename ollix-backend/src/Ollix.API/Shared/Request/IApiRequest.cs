using Ollix.Application.Abstractions;
using Ollix.SharedKernel;

namespace Ollix.API.Shared.Request
{
    public interface IApiRequest<T, Q> where T : ICommand<Q>  where Q : class
    {
        public T ToCommand();
    }
}
