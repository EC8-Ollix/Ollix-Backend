using Ardalis.Specification;

namespace Ollix.SharedKernel.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class/*, IAggregateRoot*/
{
}

