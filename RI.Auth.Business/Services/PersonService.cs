using Mapster;
using RI.Auth.Commons.Models;
using RI.Auth.DataAccess;
using RI.Auth.Domain.Models;

namespace RI.Auth.Business.Services;

internal sealed class PersonService : IPersonService
{
    private readonly IUnitOfWork _work;


    public PersonService(IUnitOfWork work)
    {
        _work = work;
    }

    public async Task Add(PersonDto dto, CancellationToken token = default)
    {
        try
        {
            var entity = dto.Adapt<Person>();
            await _work.Person.Add(entity, token);
            await _work.SaveChangesAsync(token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}