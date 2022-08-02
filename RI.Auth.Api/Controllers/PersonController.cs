using Microsoft.AspNetCore.Mvc;
using RI.Auth.Business.Services;
using RI.Auth.Common.Models;

namespace RI.Auth.Controllers;

[Route("[controller]/[action]")]
public class PersonController : Controller
{
    private readonly IPersonService _service;

    public PersonController(IPersonService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task Add([FromBody] PersonDto dto, CancellationToken token = default)
    {
        await _service.Add(dto, token);
    }
}