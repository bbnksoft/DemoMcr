using Microsoft.EntityFrameworkCore.Storage;
using REZsupport.Core.Entities;
using REZsupport.Core.Interfaces;
using REZsupport.Infrastructure.Persistence;

namespace REZsupport.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction? _transaction;

    private IRepository<Tenant>? _tenants;
    private IRepository<Company>? _companies;
    private IRepository<Contact>? _contacts;
    private IRepository<Event>? _events;
    private IRepository<Product>? _products;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<Tenant> Tenants =>
        _tenants ??= new Repository<Tenant>(_context);

    public IRepository<Company> Companies =>
        _companies ??= new Repository<Company>(_context);

    public IRepository<Contact> Contacts =>
        _contacts ??= new Repository<Contact>(_context);

    public IRepository<Event> Events =>
        _events ??= new Repository<Event>(_context);

    public IRepository<Product> Products =>
    _products ??= new Repository<Product>(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
