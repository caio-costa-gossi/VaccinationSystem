namespace VaccinationSystem.Application.Persons.GetPerson
{
    public record GetPersonDto(Guid Id, string Name, List<GetVaccinationDto> Vaccinations);
}
