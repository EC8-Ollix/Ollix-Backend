using Ollix.SharedKernel.Interfaces;
using Ollix.SharedKernel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Ollix.Domain.UserAggregate;
using Ollix.Domain.ClientAppAggregate;
using Ollix.Infrastructure.Data.DataBaseContext.Config;

namespace Ollix.Infrastructure.Data.DataBaseContext;

public class AppDbContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    public AppDbContext() : base() { }

    public AppDbContext(DbContextOptions<AppDbContext> options,
        IDomainEventDispatcher? dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<UserApp> UserApp => Set<UserApp>();
    public DbSet<ClientApp> ClientApp => Set<ClientApp>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ClientAppEfConfig());
        modelBuilder.ApplyConfiguration(new UserAppEFConfig());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        if (result == 0)
            throw new Exception("An error occurred while trying to save changes");

        if (_dispatcher == null) return result;

        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
