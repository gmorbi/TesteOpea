using Empresas.Domain.Interfaces;

namespace Empresas.Domain.Services;

public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
{
    private readonly IRepositoryBase<TEntity> _repository;

    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Commit(CancellationToken cancellationToken = default)
    {
        return await _repository.Commit(cancellationToken);
    }


    public async Task AddAsync(TEntity entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public void Remove(TEntity entity)
    {
        _repository.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _repository.Update(entity);
    }
}
