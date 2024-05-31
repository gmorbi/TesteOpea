namespace Empresas.Domain.Interfaces;

public interface IServiceBase<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(Guid id);

    Task<bool> Commit(CancellationToken cancellationToken = default);
}
