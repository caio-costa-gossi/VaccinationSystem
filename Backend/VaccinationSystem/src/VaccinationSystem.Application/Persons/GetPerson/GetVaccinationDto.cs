namespace VaccinationSystem.Application.Persons.GetPerson
{
    public record GetVaccinationDto(Guid Id, GetVaccineDto Vaccine, int DoseNumber, DateOnly AppliedAt);
}
