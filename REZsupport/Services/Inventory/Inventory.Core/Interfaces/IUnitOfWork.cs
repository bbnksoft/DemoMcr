using Inventory.Core.Entities;
namespace Inventory.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Venue> Venues { get; }
    IRepository<Section> Sections { get; }
    IRepository<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
