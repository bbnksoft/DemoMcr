using Microsoft.EntityFrameworkCore.Storage;
using Inventory.Core.Interfaces;
using Inventory.Core.Entities;
using Inventory.Infrastructure.Persistence;

namespace Inventory.Infrastructure.Repositories;

/// <summary>
/// Unit of Work implementation for managing repositories and transactions.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// The database context used for data access.
    /// </summary>
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction? _transaction;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context"></param>
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Tenants = new Repository<Tenant>(_context);
        Venues = new Repository<Venue>(_context);
        Sections = new Repository<Section>(_context);
        Products = new Repository<Product>(_context);
        ProductCategories = new Repository<ProductCategory>(_context);
    }


    /// <summary>
    /// Gets the repository for managing Venue entities.
    /// </summary>
    public IRepository<Venue> Venues { get; }

    /// <summary>
    /// Gets the repository for managing Section entities.
    /// </summary>
    public IRepository<Section> Sections { get; }

    /// <summary>
    /// Gets the repository for managing Product entities.
    /// </summary>
    public IRepository<Product> Products { get; }

    /// <summary>
    /// Gets the repository for managing Tenant entities.
    /// </summary>
    public IRepository<Tenant> Tenants { get; }

    /// <summary>
    /// Gets the repository for managing ProductCategory entities.
    /// </summary>
    public IRepository<ProductCategory> ProductCategories { get; }

    /// <summary>
    /// Saves all changes made in this unit of work to the database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Begins a new database transaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    /// <summary>
    /// Commits the current database transaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    /// <summary>
    /// Rolls back the current database transaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    /// <summary>
    /// Disposes the unit of work and its resources.
    /// </summary>
    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
