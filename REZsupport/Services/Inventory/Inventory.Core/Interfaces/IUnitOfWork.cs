using Inventory.Core.Entities;
namespace Inventory.Core.Interfaces;

/// <summary>
/// Unit of Work interface for managing repositories and transactions.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets the repository for managing Tenant entities.
    /// </summary>
    IRepository<Tenant> Tenants { get; }

    /// <summary>
    /// Gets the repository for managing Venue entities.
    /// </summary>
    IRepository<Venue> Venues { get; }

    /// <summary>
    /// Gets the repository for managing Section entities.
    /// </summary>
    IRepository<Section> Sections { get; }

    /// <summary>
    /// Gets the repository for managing Product entities.
    /// </summary>
    IRepository<Product> Products { get; }

    /// <summary>
    /// Gets the repository for managing ProductCategory entities.
    /// </summary>
    IRepository<ProductCategory> ProductCategories { get; }

    /// <summary>
    /// Saves all changes made in the unit of work to the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Begins a new transaction asynchronously.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Commits the current transaction asynchronously.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Rolls back the current transaction asynchronously.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
