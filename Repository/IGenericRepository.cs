using AllSeriesApi.DTOS.Film;
using System.Linq.Expressions;

namespace AllSeriesApi.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public Task<List<TEntity>> GetAllAsync(CancellationToken ct);
    public Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken ct);
    public void Delete(TEntity entity);
    public Task SaveAsync(CancellationToken ct);
    public Task AddAsync(TEntity entity, CancellationToken ct);
    public Task<List<TEntity>> PageAsync(int page, int size, CancellationToken ct);
    public Task<List<TEntity>> SearchAsync(Expression<Func<TEntity,bool>> expression, CancellationToken ct);
}
