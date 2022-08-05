using RI.Auth.Commons.Models;

namespace RI.Auth.Business.Services;

public interface IPersonService
{
    Task Add(PersonAddDto dto, CancellationToken token = default);
    Task<bool> Update(string? id, PersonUpdateDto dto, CancellationToken token = default);
    Task<bool> Remove(string? id, CancellationToken token = default);
    Task<List<PersonListDto>?> GetAll(CancellationToken token = default);
    Task<PersonDto?> GetOne(string? id, CancellationToken token = default);
}