using Ardalis.Specification;

namespace Ollix.SharedKernel.Interfaces;
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}


