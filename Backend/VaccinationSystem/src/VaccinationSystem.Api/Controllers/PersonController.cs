using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Application.Persons.CreatePerson;
using VaccinationSystem.Application.Persons.GetPerson;

namespace VaccinationSystem.Api.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPersonById(Guid id)
    {
        GetPersonDto personDto = await _sender.Send(new GetPersonQuery(id));
        return Ok(personDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand command)
    {
        Guid newGuid = await _sender.Send(command);
        return Ok(newGuid);
    }
}
