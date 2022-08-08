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

    public async Task Add(PersonAddDto dto, CancellationToken token = default)
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

    public async Task<bool> Update(string? id, PersonUpdateDto dto, CancellationToken token = default)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            id = id.Trim();
            var entity = await _work.Person
                .GetOne(x => x.Id == id, token);

            if (entity is null)
            {
                return false;
            }

            entity = dto.Adapt(entity);
            _work.Person.Update(entity);
            await _work.SaveChangesAsync(token);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Remove(string? id, CancellationToken token = default)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            id = id.Trim();
            var entity = await _work.Person
                .GetOne(x => x.Id == id, token);

            if (entity is null)
            {
                return false;
            }

            _work.Person.Remove(entity);
            await _work.SaveChangesAsync(token);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<PersonDto?> GetOne(string? id, CancellationToken token = default)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            id = id.Trim();

            var entity = await _work.Person
                .GetOne(x => x.Id == id, token);

            return entity?.Adapt<PersonDto>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<PersonListDto>?> GetAll(CancellationToken token = default)
    {
        try
        {
            var entities = await _work.Person
                .GetAll(token);
            return entities.Adapt<List<PersonListDto>?>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}