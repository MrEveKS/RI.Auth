namespace RI.Auth.DataAccess.Repositories;

public interface IBaseRepository<TEntity>
{
    Task<List<TEntity>> GetAll(CancellationToken cancellationToken);
    ValueTask Add(TEntity entity, CancellationToken cancellationToken);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}