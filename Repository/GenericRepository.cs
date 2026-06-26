using System.Formats.Tar;
using System.Linq.Expressions;
using AllSeriesApi.Data;
using AllSeriesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AllSeriesApi.Repository;

public class GenericRepository<TEntity>(SeriesDbContext context) : IGenericRepository<TEntity> where TEntity : class
{
    public async Task AddAsync(TEntity entity)
    {
        await context.Set<TEntity>()
        .AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>()
        .Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>()
        .ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid Id)
    {
        return await context.Set<TEntity>()
        .FindAsync(Id);
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> PageAsync(int page, int size)
    {
        return await context.Set<TEntity>()
        .AsNoTracking()
        .Skip((page - 1) * size)
        .Take(size)
        .ToListAsync();
    }

    public async Task<List<TEntity>> SearchAsync(Expression<Func<TEntity,bool>> expression)
    {
        return await context.Set<TEntity>()
        .AsNoTracking()
        .Where(expression)
        .ToListAsync();
    }
}
