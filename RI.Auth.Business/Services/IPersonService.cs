using RI.Auth.Common.Models;

namespace RI.Auth.Business.Services;

public interface IPersonService
{
    Task Add(PersonDto dto, CancellationToken token = default);
}