using RI.Auth.DataAccess.Repositories;

namespace RI.Auth.DataAccess;

public interface IUnitOfWork
{
    IPersonRepository Person { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}