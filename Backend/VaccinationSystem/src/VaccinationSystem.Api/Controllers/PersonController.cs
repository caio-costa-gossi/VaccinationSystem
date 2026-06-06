using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Application.Persons.CreatePerson;
using VaccinationSystem.Application.Persons.DeletePerson;
using VaccinationSystem.Application.Persons.GetPerson;
using VaccinationSystem.Application.Vaccinations.CreateVaccination;
using VaccinationSystem.Application.Vaccinations.DeleteVaccination;

namespace VaccinationSystem.Api.Controllers;

[ApiController]
[Route("api/persons")]
[Authorize]
public class PersonController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    // Person
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPersonById(Guid id)
    {
        GetPersonDto? personDto = await _sender.Send(new GetPersonQuery(id));
        return Ok(personDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand command)
    {
        Guid newGuid = await _sender.Send(command);
        return Ok(newGuid);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        await _sender.Send(new DeletePersonCommand(id));
        return NoContent();
    }

    // Vaccinations
    [HttpPost("{personId:guid}/vaccinations")]
    public async Task<IActionResult> CreateVaccination(
        Guid personId, [FromBody] NewVaccinationDto newVaccination)
    {
        Guid newGuid = await _sender.Send(
            new CreateVaccinationCommand(
                personId, 
                newVaccination.VaccineId, 
                newVaccination.DoseNumber, 
                newVaccination.ApplicationDate)
            );
        
        return Ok(newGuid);
    }

    [HttpDelete("{personId:guid}/vaccinations/{vaccinationId:guid}")]
    public async Task<IActionResult> DeleteVaccination(Guid personId, Guid vaccinationId)
    {
        await _sender.Send(new DeleteVaccinationCommand(personId, vaccinationId));
        return NoContent();
    }
}
