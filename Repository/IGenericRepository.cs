namespace AllSeriesApi.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public Task<List<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(Guid Id);
    public Task DeleteAsync(TEntity entity);
    public Task SaveAsync();
    public Task AddAsync(TEntity entity); 
}
