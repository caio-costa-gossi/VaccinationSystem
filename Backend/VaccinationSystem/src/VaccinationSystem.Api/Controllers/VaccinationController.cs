using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Application.Vaccinations.CreateVaccination;
using VaccinationSystem.Application.Vaccinations.DeleteVaccination;

namespace VaccinationSystem.Api.Controllers
{
    [ApiController]
    [Route("api/vaccinations")]
    public class VaccinationController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> CreateVaccination([FromBody] CreateVaccinationCommand command)
        {
            Guid newGuid = await _sender.Send(command);
            return Ok(newGuid);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteVaccination(Guid id)
        {
            await _sender.Send(new DeleteVaccinationCommand(id));
            return NoContent();
        }
    }
}
