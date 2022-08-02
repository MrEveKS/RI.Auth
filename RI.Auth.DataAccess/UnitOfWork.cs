using RI.Auth.DataAccess.Repositories;

namespace RI.Auth.DataAccess;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly AuthContext _context;
    private readonly Lazy<IPersonRepository> _personRepository;

    public UnitOfWork(AuthContext context)
    {
        _context = context;
        _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(context));
    }

    public IPersonRepository Person => _personRepository.Value;
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);
}