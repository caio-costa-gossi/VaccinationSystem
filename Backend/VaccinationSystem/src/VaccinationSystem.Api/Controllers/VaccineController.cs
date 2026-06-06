using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Application.Vaccines.CreateVaccine;
using VaccinationSystem.Application.Vaccines.DeleteVaccine;
using VaccinationSystem.Application.Vaccines.GetVaccines;

namespace VaccinationSystem.Api.Controllers
{
    [ApiController]
    [Route("api/vaccines")]
    [Authorize]
    public class VaccineController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetVaccines()
        {
            List<GetVaccinesItemDto> vaccines = await _sender.Send(new GetVaccinesQuery());
            return Ok(vaccines);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVaccine([FromBody] CreateVaccineCommand command)
        {
            Guid newGuid = await _sender.Send(command);
            return Ok(newGuid);
        }

        [HttpDelete("{vaccineId:guid}")]
        public async Task<IActionResult> DeleteVaccine(Guid vaccineId)
        {
            await _sender.Send(new DeleteVaccineCommand(vaccineId));
            return NoContent();
        }
    }
}
