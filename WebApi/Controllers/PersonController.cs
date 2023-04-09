using Application;
using Application.PersonServices;
using Application.PersonServices.InputModels;
using Application.PersonServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonController
{
    private readonly IPersonService _service;

    public PersonController(IPersonService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedResult<PersonViewModel>> GetAll([FromQuery] PagedResultInputModel model) => _service.GetAll(model);

    [HttpGet("{id:long}")]
    public Task<PersonViewModel> Get(long id) => _service.Get(id);

    [HttpPut("{id:long}")]
    public Task ChangeInfo(long id, [FromBody] PersonInputModel model) => _service.Update(id, model);

    [HttpPost]
    public Task<long> Create([FromBody] PersonInputModel model) => _service.Add(model);

    [HttpDelete("{id:long}")]
    public Task Remove(long id) => _service.Remove(id);

}