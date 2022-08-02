using RI.Auth.Domain.Models;

namespace RI.Auth.DataAccess.Repositories;

internal sealed class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(AuthContext context) : base(context)
    {
    }
}