namespace VaccinationSystem.Application.Persons.GetPerson
{
    public record GetVaccinationDto(Guid Id, Guid VaccineId, int DoseNumber, DateTime AppliedAt);
}
