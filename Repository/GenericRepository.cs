using System.Formats.Tar;
using System.Linq.Expressions;
using AllSeriesApi.Data;
using AllSeriesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AllSeriesApi.Repository;

public class GenericRepository<TEntity>(SeriesDbContext context) : IGenericRepository<TEntity> where TEntity : class
{
    public async Task AddAsync(TEntity entity, CancellationToken ct)
    {
        await context.Set<TEntity>()
        .AddAsync(entity, ct);
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>()
        .Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken ct)
    {
        return await context.Set<TEntity>()
        .ToListAsync(ct);
    }

    public async Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken ct)
    {
        return await context.Set<TEntity>()
        .FindAsync(Id, ct);
    }

    public async Task SaveAsync(CancellationToken ct)
    {
        await context.SaveChangesAsync(ct);
    }

    public async Task<List<TEntity>> PageAsync(int page, int size, CancellationToken ct)
    {
        return await context.Set<TEntity>()
        .AsNoTracking()
        .Skip((page - 1) * size)
        .Take(size)
        .ToListAsync(ct);
    }

    public async Task<List<TEntity>> SearchAsync(Expression<Func<TEntity,bool>> expression, CancellationToken ct)
    {
        return await context.Set<TEntity>()
        .AsNoTracking()
        .Where(expression)
        .ToListAsync(ct);
    }
}
