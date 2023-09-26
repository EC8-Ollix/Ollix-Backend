using Ardalis.Specification;
using Ollix.SharedKernel;

namespace Ollix.Domain.Shared.Specifications
{
    public class GetByIdSpec<T> : SingleResultSpecification<T> where T : EntityBase
    {
        public GetByIdSpec(Guid id)
        {
            if (id != default)
                Query.Where(entity => entity.Id == id);
        }
    }
}
