using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinationSystem.Application.Persons.GetPerson
{
    public record GetPersonDto(Guid Id, string Name, List<VaccinationDto> Vaccinations);
}
