using Microsoft.AspNetCore.Mvc;

namespace VaccinationSystem.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    public IActionResult GetPersons()
    {
        return Ok();
    }
}
