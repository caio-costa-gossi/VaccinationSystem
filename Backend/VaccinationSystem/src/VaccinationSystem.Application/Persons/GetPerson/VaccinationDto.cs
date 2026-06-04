using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinationSystem.Application.Persons.GetPerson
{
    public record VaccinationDto(Guid Id, Guid VaccineId, int DoseNumber, DateTime AppliedAt);
}
