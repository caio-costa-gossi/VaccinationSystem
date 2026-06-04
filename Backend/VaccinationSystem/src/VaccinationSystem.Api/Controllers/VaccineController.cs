using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Application.Vaccines.GetVaccines;

namespace VaccinationSystem.Api.Controllers
{
    [ApiController]
    [Route("api/vaccines")]
    public class VaccineController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetVaccines()
        {
            List<GetVaccinesItemDto> vaccines = await _sender.Send(new GetVaccinesQuery());
            return Ok(vaccines);
        }
    }
}
