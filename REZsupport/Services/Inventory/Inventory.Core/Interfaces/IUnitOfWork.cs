namespace Inventory.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Entities.Venue> Venues { get; }
    IRepository<Entities.Section> Sections { get; }
    IRepository<Entities.Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
