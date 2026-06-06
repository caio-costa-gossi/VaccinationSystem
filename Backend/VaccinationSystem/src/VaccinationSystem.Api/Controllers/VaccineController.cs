using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Application.Vaccines.CreateVaccine;
using VaccinationSystem.Application.Vaccines.GetVaccines;

namespace VaccinationSystem.Api.Controllers
{
    [ApiController]
    [Route("api/vaccines")]
    public class VaccineController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetVaccines()
        {
            List<GetVaccinesItemDto> vaccines = await _sender.Send(new GetVaccinesQuery());
            return Ok(vaccines);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVaccine([FromBody] CreateVaccineCommand command)
        {
            Guid newGuid = await _sender.Send(command);
            return Ok(newGuid);
        }
    }
}
