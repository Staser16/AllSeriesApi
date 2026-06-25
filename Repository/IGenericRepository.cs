using AllSeriesApi.DTOS.Film;
using System.Linq.Expressions;

namespace AllSeriesApi.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public Task<List<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(Guid Id);
    public Task DeleteAsync(TEntity entity);
    public Task SaveAsync();
    public Task AddAsync(TEntity entity);
    public Task<List<TEntity>> PageAsync(int page, int size);
    public Task<List<TEntity>> SearchAsync(Expression<Func<TEntity,bool>> expression); 
}
