using Microsoft.AspNetCore.Mvc;
using RI.Auth.Business.Services;
using RI.Auth.Commons.Models;

namespace RI.Auth.Api.Controllers;

[Route("[controller]/[action]")]
public class PersonController : Controller
{
    private readonly IPersonService _service;

    public PersonController(IPersonService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task Add([FromBody] PersonAddDto dto, CancellationToken token = default)
    {
        await _service.Add(dto, token);
    }

    [HttpPost("{id}")]
    public async Task Update([FromRoute] string? id,
        [FromBody] PersonUpdateDto dto, CancellationToken token = default)
    {
        await _service.Update(id, dto, token);
    }

    [HttpDelete]
    public async Task Remove([FromQuery] string? id, CancellationToken token = default)
    {
        await _service.Remove(id, token);
    }

    [HttpGet("{id}")]
    public async Task<PersonDto?> GetOne([FromRoute] string? id, CancellationToken token = default)
    {
        return await _service.GetOne(id, token);
    }

    [HttpPost]
    public async Task<List<PersonListDto>?> GetAll(CancellationToken token = default)
    {
        return await _service.GetAll(token);
    }
}