using Microsoft.EntityFrameworkCore;

namespace RI.Auth.DataAccess.Repositories;

internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly AuthContext _context;
    
    protected BaseRepository(AuthContext context)
    {
        _context = context;
    }

    public Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
    {
        return _context.Set<TEntity>()
            .ToListAsync(cancellationToken);
    }

    public async ValueTask Add(TEntity entity, CancellationToken cancellationToken)
    {
        await _context.Set<TEntity>()
            .AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}