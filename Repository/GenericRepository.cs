using System.Formats.Tar;
using AllSeriesApi.Data;
using AllSeriesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AllSeriesApi.Repository;

public class GenericRepository<TEntity>(SeriesDbContext context) : IGenericRepository<TEntity> where TEntity : class
{
    public async Task AddAsync(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid Id)
    {
        return await context.Set<TEntity>().FindAsync(Id);
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}
