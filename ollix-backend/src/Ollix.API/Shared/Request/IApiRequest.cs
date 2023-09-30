using MediatR;

namespace Ollix.API.Shared.Request
{
    public interface IApiRequest<T, Q> where T : IRequest<Q> where Q : class
    {
        public T ToCommand();
    }
}
