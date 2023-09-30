using Ardalis.Specification.EntityFrameworkCore;
using Ollix.Infrastructure.Data.DataBaseContext;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Infrastructure.Data.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(AppDbContext dbContext) : base(dbContext)
    {

    }

}

