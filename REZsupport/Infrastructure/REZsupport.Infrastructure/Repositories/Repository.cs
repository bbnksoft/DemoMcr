using Microsoft.EntityFrameworkCore;
using REZsupport.Core.Entities;
using REZsupport.Core.Interfaces;
using REZsupport.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace REZsupport.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    //public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    //{
    //    return await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
    //}

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public Task<IQueryable<T>> GetAllQueryAsync(CancellationToken cancellationToken = default)
    {
        // No async DB call happens here
        IQueryable<T> query = _context.Set<T>().AsQueryable();

        return Task.FromResult(query);
    }

    public Task<IQueryable<T>> GetQueryAsync(Func<IQueryable<T>, IQueryable<T>>? include = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();

        if (include != null)
            query = include(query);

        return Task.FromResult(query);
    }
}
