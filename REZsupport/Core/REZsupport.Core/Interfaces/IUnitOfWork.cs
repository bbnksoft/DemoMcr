using REZsupport.Core.Entities;

namespace REZsupport.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Tenant> Tenants { get; }
    IRepository<Company> Companies { get; }
    IRepository<Contact> Contacts { get; }
    IRepository<Event> Events { get; }
    IRepository<Product> Products { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
